﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DAL.Models
{
    public class PatientMedicine:BaseEntity
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
    }
}
