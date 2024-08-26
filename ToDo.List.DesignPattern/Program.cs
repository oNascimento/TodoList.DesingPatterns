using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.List.DesignPattern.Core.Contexts;
using ToDo.List.DesignPattern.Core.MapperProfiles;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Core.Repositories;
using ToDo.List.DesignPattern.Core.Services.Commands.CreateTodoItemCommand;
using ToDo.List.DesignPattern.Infrastructure;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;
using ToDo.List.DesignPattern.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<MongoDbSettings>(
            builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<TodoMongoDbContext>();

builder.Services.AddTransient<IEFRepository<TodoItem>, TodoItemEFRepository>();
builder.Services.AddTransient<IEFRepository<User>, UserEFRepository>();
builder.Services.AddTransient<INoSqlRepository<TodoItem>, TodoItemNoSqlRepository>();

builder.Services.AddAutoMapper(typeof(TodoItemMapperProfile));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(CreateTodoItemValidator).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
