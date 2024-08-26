using FluentValidation;

namespace ToDo.List.DesignPattern.Core.Services.Commands.CreateUserCommand;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.User.Name).NotEmpty().WithMessage("Username is required.");
        RuleFor(x => x.User.UserName).NotEmpty().WithMessage("Username is required.");
        RuleFor(x => x.User.Password).NotEmpty().WithMessage("Password is required.");
    }
}