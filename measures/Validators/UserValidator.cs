using FluentValidation;
using Measure.Domain.DTOs.WriteDTO;
using System.Text.RegularExpressions;

namespace Measures.Validators
{
    public class UserValidator : AbstractValidator<SetUserDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name cannot be empty or whitespace.")
                .MinimumLength(2).WithMessage("Name must be atleast 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 character.");

            RuleFor(u => u.LastName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Lastname cannot be empty or whitespace.")
                .MinimumLength(2).WithMessage("Lastname must be atleast 2 characters.")
                .MaximumLength(80).WithMessage("Lastname cannot exceed 80 characters.");

            RuleFor(u => u.Email).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .MaximumLength(256).WithMessage("Email cannot exceed 256 characters.")
                .EmailAddress().WithMessage("Must be a valid e-mail adress.");

            RuleFor(u => u.Password).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .Must(password =>
                {
                    bool hasLowercase = Regex.IsMatch(password, "[a-z]");
                    bool hasUppercase = Regex.IsMatch(password, "[A-Z]");
                    bool hasDigit = Regex.IsMatch(password, "\\d");
                    bool hasSpecialChar = Regex.IsMatch(password, "[!@#$%^&*()_+]");

                    return hasLowercase && hasUppercase && hasDigit && hasSpecialChar;
                })
                .WithMessage("Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character (!@#$%^&*()_+).");

            RuleFor(u => u.UserName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .MinimumLength(2).WithMessage("Username must be atleast 2 characters.")
                .MaximumLength(50).WithMessage("Username cannot exceed 50 character.");

        }
    }
}
