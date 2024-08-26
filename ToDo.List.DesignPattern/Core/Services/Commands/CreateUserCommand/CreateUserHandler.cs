using AutoMapper;
using MediatR;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

namespace ToDo.List.DesignPattern.Core.Services.Commands.CreateUserCommand
{
    public class CreateUserHandler(IEFUserRepository _userRepository, IMapper _mapper) : IRequestHandler<CreateUserCommand>
    {
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.User);
            await _userRepository.Create(user);
        }
    }
}