using MediatR;
using ToDo.List.DesignPattern.Core.Models.DTOs;

namespace ToDo.List.DesignPattern.Core.Services.Queries.GetAllTodoItemQuery
{
    public class GetAllTodoItemQuery : IRequest<IEnumerable<TodoItemDto>>
    {
        
    }
}