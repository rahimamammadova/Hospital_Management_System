using FluentValidation;
using HMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BLL.Validations
{
    public class MedicineValidator : AbstractValidator<Medicine>
    {
        public MedicineValidator()
        {

            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Medicine name is required.").MaximumLength(256)
    .WithMessage("Medicine name can't contain more than 256 characters.");

        }
    }
}
