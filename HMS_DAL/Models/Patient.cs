using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DAL.Models
{
    public class Patient: Person
    {

        public int UserId { get; set; }
        public User User { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set;}

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<PatientMedicine> PatientMedicines { get; set;}=new List<PatientMedicine>();

    }
}
