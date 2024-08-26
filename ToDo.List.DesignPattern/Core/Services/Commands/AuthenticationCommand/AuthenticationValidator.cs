using FluentValidation;

namespace ToDo.List.DesignPattern.Core.Services.Commands.AuthenticationCommand
{
    public class AuthenticationValidator : AbstractValidator<AuthenticationCommand>
    {
        public AuthenticationValidator()
        {
            RuleFor(x => x.UserLogin.UserName).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.UserLogin.Password).NotEmpty().WithMessage("Password is required.");
        }
    }
}