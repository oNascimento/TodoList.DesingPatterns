using MediatR;

namespace ToDo.List.DesignPattern.Core.Services.Commands.DeleteTodoItemCommand
{
    public class DeleteTodoItemCommand : IRequest
    {
        public long Id { get; set; }
    }
}