using FluentValidation;

namespace ToDo.List.DesignPattern.Core.Services.Commands.CreateTodoItemCommand;

public class CreateTodoItemValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoItemValidator()
    {
        RuleFor(x => x.TodoItem.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(x => x.TodoItem.DueDate).GreaterThan(DateTime.Now).WithMessage("Due date must be in the future.");
    }
}