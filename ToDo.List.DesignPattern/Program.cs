using Microsoft.EntityFrameworkCore;
using ToDo.List.DesignPattern.Core.Contexts;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Core.Repositories;
using ToDo.List.DesignPattern.Infrastructure;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<MongoDbSettings>(
            builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<TodoMongoDbContext>();
builder.Services.AddSingleton<IEFRepository<TodoItem>, TodoItemEFRepository>();
builder.Services.AddSingleton<INoSqlRepository<TodoItem>, TodoItemNoSqlRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
