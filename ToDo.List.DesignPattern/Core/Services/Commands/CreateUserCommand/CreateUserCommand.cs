using MediatR;
using ToDo.List.DesignPattern.Core.Models.DTOs;

namespace ToDo.List.DesignPattern.Core.Services.Commands.CreateUserCommand;

public class CreateUserCommand : IRequest
{
    public required UserDto User { get; set; }
}