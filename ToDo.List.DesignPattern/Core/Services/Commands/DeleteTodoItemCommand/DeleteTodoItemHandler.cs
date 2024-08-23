using MediatR;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

namespace ToDo.List.DesignPattern.Core.Services.Commands.DeleteTodoItemCommand
{
    public class DeleteTodoItemHandler(IEFRepository<TodoItem> _repository) : IRequestHandler<DeleteTodoItemCommand>
    {
        public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
        }
    }
}