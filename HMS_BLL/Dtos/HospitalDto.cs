using HMS_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BLL.Dtos
{
    public class HospitalDto : BaseDto
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public HospitalType Type { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
    }
}
