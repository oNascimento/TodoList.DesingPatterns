using AutoMapper;
using MediatR;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

namespace ToDo.List.DesignPattern.Core.Services.Commands.CreateTodoItemCommand;

public class CreateTodoItemHandler(IMapper _mapper, IRepository<TodoItem> _repository) : IRequestHandler<CreateTodoItemCommand, long>
{
    public async Task<long> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = _mapper.Map<TodoItem>(request.TodoItem);
        await _repository.Create(todoItem);
        return todoItem.Id;
    }
}