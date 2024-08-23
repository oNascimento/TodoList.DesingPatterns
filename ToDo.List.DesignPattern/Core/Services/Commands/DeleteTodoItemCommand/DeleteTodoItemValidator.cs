using FluentValidation;
using ToDo.List.DesignPattern.Core.Models.DTOs;

namespace ToDo.List.DesignPattern.Core.Services.Commands.DeleteTodoItemCommand;

public class DeleteTodoItemValidator : AbstractValidator<TodoItemDto>
{
    public DeleteTodoItemValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(x => x.DueDate).GreaterThan(DateTime.Now).WithMessage("Due date must be in the future.");
    }
}