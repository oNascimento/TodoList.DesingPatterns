using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.List.DesignPattern.Core.Services.Commands.CreateTodoItemCommand;
using ToDo.List.DesignPattern.Core.Services.Commands.DeleteTodoItemCommand;
using ToDo.List.DesignPattern.Core.Services.Commands.UpdateTodoItemCommand;

namespace ToDo.List.DesignPattern.Controllers.V2
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItem(CreateTodoItemCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);
                return Ok(id);
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
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            try
            {
                var command = new DeleteTodoItemCommand { Id = id };
                await _mediator.Send(command);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }
    }
}