using AutoMapper;
using MediatR;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Core.Models.DTOs;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

namespace ToDo.List.DesignPattern.Core.Services.Queries.GetTodoItemQuery
{
    public class GetTodoItemQueryHandler(IEFRepository<TodoItem> _repository, IMapper _mapper) : IRequestHandler<GetTodoItemQuery, TodoItemDto>
    {
        public async Task<TodoItemDto> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<TodoItemDto>(await _repository.Get(request.Id));
        }
    }
}