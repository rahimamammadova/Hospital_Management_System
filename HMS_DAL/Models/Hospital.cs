using HMS_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DAL.Models
{
    public class Hospital:BaseEntity
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public HospitalType Type { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
        public ICollection<Nurse> Nurses { get; set; } = new List<Nurse>();
    }
}
