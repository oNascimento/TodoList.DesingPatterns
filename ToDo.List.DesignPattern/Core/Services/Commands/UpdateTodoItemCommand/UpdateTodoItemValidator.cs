using FluentValidation;

namespace ToDo.List.DesignPattern.Core.Services.Commands.UpdateTodoItemCommand;

public class UpdateTodoItemValidator : AbstractValidator<UpdateTodoItemCommand>
{
    public UpdateTodoItemValidator()
    {
        RuleFor(x => x.TodoItem.Id).NotNull().NotEmpty().WithMessage("Title is required.");
        RuleFor(x => x.TodoItem.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(x => x.TodoItem.DueDate).GreaterThan(DateTime.Now).WithMessage("Due date must be in the future.");
    }
}