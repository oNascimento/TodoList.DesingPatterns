using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.List.DesignPattern.Core.Services.Commands.CreateTodoItemCommand;
using ToDo.List.DesignPattern.Core.Services.Commands.DeleteTodoItemCommand;
using ToDo.List.DesignPattern.Core.Services.Commands.UpdateTodoItemCommand;
using ToDo.List.DesignPattern.Core.Services.Queries.GetAllTodoItemQuery;
using ToDo.List.DesignPattern.Core.Services.Queries.GetTodoItemQuery;

namespace ToDo.List.DesignPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoItemController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTodoItem(CreateTodoItemCommand command)
    {
        try
        {
            var id = await _mediator.Send(command);
            return Created();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTodoItem(UpdateTodoItemCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {
        try
        {
            var command = new DeleteTodoItemCommand { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoItem(long id)
    {
        try
        {
            var command = new GetTodoItemQuery { Id = id };
            return Ok(await _mediator.Send(command));
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTodoItem()
    {
        try
        {
            var command = new GetAllTodoItemQuery();
            return Ok(await _mediator.Send(command));
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
    }
}