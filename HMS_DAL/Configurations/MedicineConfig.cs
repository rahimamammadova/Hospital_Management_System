using HMS_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DAL.Configurations
{
    public class MedicineConfig:IEntityTypeConfiguration<Medicine>
    {
     
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasMany(m => m.PatientMedicines)
                .WithOne(md => md.Medicine)
                .HasForeignKey(md => md.MedicineId);
        }
    }
}
