using MediatR;
using ToDo.List.DesignPattern.Core.Models.DTOs;

namespace ToDo.List.DesignPattern.Core.Services.Commands.CreateTodoItemCommand;

public class CreateTodoItemCommand : IRequest<TodoItemDto>
{
    public required TodoItemDto TodoItem { get; set; }
}