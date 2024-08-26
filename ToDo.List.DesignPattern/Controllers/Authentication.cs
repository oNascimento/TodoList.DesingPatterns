using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.List.DesignPattern.Core.Services.Commands.AuthenticationCommand;

namespace ToDo.List.DesignPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Authentication(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(AuthenticationCommand authenticationCommand)
    {
        try
        {
            var token = await _mediator.Send(authenticationCommand);
            return Ok(token);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex);
        }

    }
}