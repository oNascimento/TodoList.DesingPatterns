using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.List.DesignPattern.Core.Services.Commands.CreateUserCommand;

namespace ToDo.List.DesignPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator _mediator) : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Created();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
    }
}