using MediatR;
using ToDo.List.DesignPattern.Core.Models.DTOs;

namespace ToDo.List.DesignPattern.Core.Services.Commands.AuthenticationCommand;

public class AuthenticationCommand : IRequest<string>
{
    public required UserLogin UserLogin { get; set; }
}