using HMS_DAL.Configurations;
using HMS_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorConfig).Assembly);
            base.OnModelCreating(modelBuilder);
  

        }

        public DbSet<Hospital>Hospitals { get; set; }
        public DbSet<Doctor>Doctors { get; set; }
        public DbSet<Nurse>Nurses { get; set; }
        public DbSet<Medicine>Medicines { get; set; }
        public DbSet<Patient>Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment>Appointments { get; set; }
    }
}
