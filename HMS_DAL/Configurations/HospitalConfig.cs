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
    public class HospitalConfig : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(256);

            builder.HasMany(d => d.Doctors)
                .WithOne(h => h.Hospital)
                .HasForeignKey(h => h.HospitalId)
                .IsRequired();
            builder.HasMany(n=>n.Nurses)
                .WithOne(h=>h.Hospital)
                .HasForeignKey(h=>h.HospitalId)
                .IsRequired();
        }
    }
}
