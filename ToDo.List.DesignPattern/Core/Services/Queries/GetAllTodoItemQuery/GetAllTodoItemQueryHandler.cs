using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Core.Models.DTOs;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

namespace ToDo.List.DesignPattern.Core.Services.Queries.GetAllTodoItemQuery
{
    public class GetAllTodoItemQueryHandler(IEFRepository<TodoItem> _repository, IMapper _mapper) : IRequestHandler<GetAllTodoItemQuery, IEnumerable<TodoItemDto>>
    {
        public async Task<IEnumerable<TodoItemDto>> Handle(GetAllTodoItemQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<TodoItemDto>>(await _repository.GetAllAsync());
        }
    }
}