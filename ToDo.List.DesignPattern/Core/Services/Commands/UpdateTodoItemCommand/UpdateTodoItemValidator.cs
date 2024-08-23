using FluentValidation;
using ToDo.List.DesignPattern.Core.Models.DTOs;

namespace ToDo.List.DesignPattern.Core.Services.Commands.UpdateTodoItemCommand;

public class UpdateTodoItemValidator : AbstractValidator<TodoItemDto>
{
    public UpdateTodoItemValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(x => x.DueDate).GreaterThan(DateTime.Now).WithMessage("Due date must be in the future.");
    }
}