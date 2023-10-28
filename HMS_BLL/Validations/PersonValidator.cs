using FluentValidation;
using HMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BLL.Validations
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().NotNull().WithMessage("Firstname is required.").MaximumLength(256)
                       .WithMessage("Firstname can't contain more than 256 characters.");
            RuleFor(x => x.Lastname).NotEmpty().NotNull().WithMessage("Lastname is required.").MaximumLength(256)
                      .WithMessage("Lastname can't contain more than 256 characters.");
            RuleFor(x => x.Phonenumber).NotNull().WithMessage("Phone number is required.").MinimumLength(5)
                .WithMessage("Phone number must not be less than 4 characters.")
                .MaximumLength(7).WithMessage("Phone number can't be less than 7 characters.");
        }
    }
}
