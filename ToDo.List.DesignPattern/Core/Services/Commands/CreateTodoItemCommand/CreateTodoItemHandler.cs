using AutoMapper;
using MediatR;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Core.Models.DTOs;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

namespace ToDo.List.DesignPattern.Core.Services.Commands.CreateTodoItemCommand;

public class CreateTodoItemHandler(IMapper _mapper, IEFRepository<TodoItem> _repository) : IRequestHandler<CreateTodoItemCommand, TodoItemDto>
{
    public async Task<TodoItemDto> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = _mapper.Map<TodoItem>(request.TodoItem);
        
        todoItem.UUId = Guid.NewGuid().ToString();

        await _repository.Create(todoItem);
        return _mapper.Map<TodoItemDto>(todoItem);
    }
}