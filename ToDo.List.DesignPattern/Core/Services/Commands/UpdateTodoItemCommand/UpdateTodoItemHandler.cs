using AutoMapper;
using MediatR;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Core.Models.DTOs;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

namespace ToDo.List.DesignPattern.Core.Services.Commands.UpdateTodoItemCommand;

public class UpdateTodoItemHandler(IMapper _mapper, IEFRepository<TodoItem> _repository) : IRequestHandler<UpdateTodoItemCommand, TodoItemDto>
{
    public async Task<TodoItemDto> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = _mapper.Map<TodoItem>(request.TodoItem);
        await _repository.Update(todoItem);
        return _mapper.Map<TodoItemDto>(todoItem);
    }
}