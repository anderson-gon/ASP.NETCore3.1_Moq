using FluentValidation;

namespace Moq.Domain.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("Invalid First Name");
        }
    }
}
