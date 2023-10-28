using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DAL.Models
{
    public class Medicine:BaseEntity
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Composition { get; set; }
        public decimal Cost{ get; set; }
        public string Type { get; set; }
        public int Dose { get; set; }
        public string DoseType { get; set; }
        public string Description { get; set; }

        public ICollection<PatientMedicine> PatientMedicines { get; set; } = new List<PatientMedicine>();

    }
}
