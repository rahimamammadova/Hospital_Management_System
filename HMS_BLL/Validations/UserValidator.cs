using FluentValidation;
using HMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BLL.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("Username is required")
               .MinimumLength(4).WithMessage("Username can't contain less than 4 characters")
               .MaximumLength(50).WithMessage("Username can't contain more than 50 characters");
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().WithMessage("Phone number is required.").MinimumLength(5)
                .WithMessage("Phone number must not be less than 4 characters.")
                .MaximumLength(7).WithMessage("Phone number can't be less than 7 characters.");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Please type valid email address.");
            RuleFor(p => p.Password).NotEmpty().NotNull().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                    .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");

        }
    }
}
