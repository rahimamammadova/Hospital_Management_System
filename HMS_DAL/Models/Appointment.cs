using HMS_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DAL.Models
{
    public class Appointment:BaseEntity
    {
        public int Number { get; set; }
        public AppointmentType Type { get; set; }
        public string Description { get; set;}
        public DateTime Date { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
