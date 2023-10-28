using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BLL.Dtos
{
    public class NurseDto : PersonDto
    {
        public string DutyHour { get; set; }
        public string Address { get; set; }

        public int HospitalId { get; set; }
        public int UserId { get; set; }
    }
}
