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
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(x => x.Firstname).IsRequired().HasMaxLength(256);

            builder.HasMany(a=>a.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(b=>b.PatientId)
                .IsRequired();

            builder.HasMany(m => m.PatientMedicines)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);
        }
    }
}
