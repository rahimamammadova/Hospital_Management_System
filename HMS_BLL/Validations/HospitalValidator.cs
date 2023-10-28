using FluentValidation;
using HMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BLL.Validations
{
    public class HospitalValidator : AbstractValidator<Hospital>
    {
        public HospitalValidator() {
            RuleFor(x => x.HospitalName).NotEmpty().NotNull().WithMessage("Hospital name is required.").MaximumLength(256)
                .WithMessage("Hospital name can't contain more than 256 characters.");
        }
    }
}
