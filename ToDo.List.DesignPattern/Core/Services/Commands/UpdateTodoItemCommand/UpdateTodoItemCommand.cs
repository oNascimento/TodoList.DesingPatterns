
using MediatR;
using ToDo.List.DesignPattern.Core.Models.DTOs;

namespace ToDo.List.DesignPattern.Core.Services.Commands.UpdateTodoItemCommand;

public class UpdateTodoItemCommand : IRequest<TodoItemDto>
{
    public required TodoItemDto TodoItem { get; set; }
}