using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Core.Models.DTOs;
using ToDo.List.DesignPattern.Core.Repositories;
using ToDo.List.DesignPattern.Core.Services.Commands.CreateTodoItemCommand;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

namespace ToDo.List.DesignPattern.Test.Handlers;

[TestClass]
public class CreateTodoItemCommandTests
{
    private readonly IMediator _mediator;
    private readonly Mock<IEFRepository<TodoItem>> _repositoryMock;
    private readonly Mock<IMapper> _mapperMock;

    public CreateTodoItemCommandTests()
    {
        var services = new ServiceCollection();
        
        var loggerMock = new Mock<ILogger<TodoItemEFRepository>>();
        _repositoryMock = new Mock<IEFRepository<TodoItem>>();
        _mapperMock = new Mock<IMapper>();

        services.AddSingleton(loggerMock.Object);
        services.AddSingleton(_repositoryMock.Object);
        services.AddSingleton(_mapperMock.Object);

        var serviceProvider = services
        .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateTodoItemHandler).Assembly))
        .BuildServiceProvider();

        var mediator = serviceProvider.GetRequiredService<IMediator>();
        
        _mediator = mediator;
    }
    
    [TestMethod]
    public async Task Should_CreateTodoItemCommand_Create_A_New_TodoItem()
    {
        #region Arrange

        var todoItemToSend = new TodoItemDto
        {
            Description = "Any Description",
            DueDate = DateTime.Now.AddDays(1),
            IsCompleted = false,
            Title = "Any Title"
        };

        var todoItemMap = new TodoItem
        {
            Id = 0,
            Description = "Any Description",
            DueDate = DateTime.Now.AddDays(1),
            IsCompleted = false,
            Title = "Any Title"
        };

        _mapperMock.Setup(m => m.Map<TodoItem>(todoItemToSend)).Returns(todoItemMap);
        _repositoryMock.Setup(r => r.Create(todoItemMap)).Callback(() => todoItemMap.Id ++);
        _mapperMock.Setup(m => m.Map<TodoItemDto>(todoItemMap)).Returns(
            new TodoItemDto
            {
                Id = 1,
                Description = "Any Description",
                DueDate = DateTime.Now.AddDays(1),
                IsCompleted = false,
                Title = "Any Title"
            }
        );
        #endregion Arrange

        #region Act
        var response = await _mediator.Send(new CreateTodoItemCommand()
        {
            TodoItem = todoItemToSend
        });
        #endregion Act

        #region Assert
        Assert.AreEqual(todoItemToSend.Description, response.Description);
        Assert.AreEqual(todoItemToSend.Title, response.Title);
        Assert.AreEqual(todoItemToSend.IsCompleted, response.IsCompleted);
        Assert.AreEqual(todoItemToSend.DueDate.Date, response.DueDate.Date);
        #endregion Assert
    }
}