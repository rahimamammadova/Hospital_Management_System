using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BLL.Dtos
{
    public class PersonDto:BaseDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FatherName { get; set; }
        public string Phonenumber { get; set; }
    }
}
