using HMS_DAL.Enums;
using HMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BLL.Dtos
{
    public class AppointmentDto:BaseDto
    {
        public int Number { get; set; }
        public AppointmentType Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
