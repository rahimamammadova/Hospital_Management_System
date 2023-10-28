using HMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BLL.Dtos
{
    public class PatientDto : PersonDto
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }

    }
}
