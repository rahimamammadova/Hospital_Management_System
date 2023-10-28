using FluentValidation;
using HMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BLL.Validations
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator() {

            RuleFor(x => x.DoctorId).NotEmpty().NotNull().WithMessage("Doctor id is required.");
            RuleFor(x => x.PatientId).NotEmpty().NotNull().WithMessage("Patient id is required.");
            RuleFor(x => x.Date).NotNull().WithMessage("Appointment date is required.")
                .GreaterThan(x=>DateTime.Now).WithMessage("Appointment date can't be scheduled for current time.");

        }
    }
}
