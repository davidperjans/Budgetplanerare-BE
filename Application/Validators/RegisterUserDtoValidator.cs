using Application.Dto;
using FluentValidation;
namespace Application.Validators;

public class RegisterUserDtoValidator : AbstractValidator<UserDto>
{
    public RegisterUserDtoValidator()
    {
        RuleFor(u => u.UserName)
            .NotEmpty().WithMessage("Användarnamn krävs.")
            .Length(3, 30).WithMessage("Användarnamn måste vara mellan 3 och 30 tecken.");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("E-postadress krävs.")
            .EmailAddress().WithMessage("Ogiltig e-postadress.");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Lösenord krävs.")
            .MinimumLength(6).WithMessage("Lösenord måste vara minst 6 tecken.");
    }
}
