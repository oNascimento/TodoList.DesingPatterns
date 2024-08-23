using MediatR;
using ToDo.List.DesignPattern.Core.Models.DTOs;

namespace ToDo.List.DesignPattern.Core.Services.Queries.GetTodoItemQuery
{
    public class GetTodoItemQuery : IRequest<TodoItemDto>
    {
        public long Id { get; set; }
    }
}