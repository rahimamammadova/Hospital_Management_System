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
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(x=>x.Firstname).IsRequired().HasMaxLength(256);

            builder.HasMany(a => a.Appointments)
                .WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId)
                .IsRequired();
        }
    }
}
