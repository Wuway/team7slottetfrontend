using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using slotlib.Models;

namespace slotlib.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<ResponsibilityTemplate> ResponsibilityTemplates => Set<ResponsibilityTemplate>();
        public DbSet<Responsibility> Responsibilities => Set<Responsibility>();
        // public DbSet<ShiftTask> ShiftTasks => Set<ShiftTask>();
        // ... resten af dine entities ...
        //public DbSet<Department> Departments => Set<Department>();
        //public DbSet<Medication> Medications => Set<Medication>();
        //public DbSet<MedicationDays> MedicationDays => Set<MedicationDays>();
        //public DbSet<MedicationDosage> MedicationDosages => Set<MedicationDosage>();
        //public DbSet<OverlapSchedule> OverlapSchedules => Set<OverlapSchedule>();
        //public DbSet<PatientTime> PatientTime => Set<PatientTime>();
        //public DbSet<PhoneAssignment> PhoneAssignments => Set<PhoneAssignment>();
        //public DbSet<Reminder> Reminders => Set<Reminder>();
        //public DbSet<Resident> Residents => Set<Resident>();
        //public DbSet<ScheduleMedication> ScheduleMedication => Set<ScheduleMedication>();
        //public DbSet<ShiftTask> ShiftTasks => Set<ShiftTask>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User -> Responsibilities (1..many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Responsibilities)
                .WithOne(r => r.AssignedUser)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Template -> Instances (1..many)
            modelBuilder.Entity<ResponsibilityTemplate>()
                .HasMany(t => t.Instances)
                .WithOne(i => i.Template)
                .HasForeignKey(i => i.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unik pr template pr dag+shift (undgå dubletter)
            modelBuilder.Entity<Responsibility>()
                .HasIndex(r => new { r.TemplateId, r.TaskDate, r.Shift })
                .IsUnique();

            // Responsibility: (dato + shift) bruges tit til filtrering
            modelBuilder.Entity<Responsibility>()
                .HasIndex(r => new { r.TaskDate, r.Shift });

            // Hvis du vil sikre rækkefølge pr. dato+shift (SortOrder)
            modelBuilder.Entity<Responsibility>()
                .HasIndex(r => new { r.TaskDate, r.Shift, r.SortOrder });
        }
    }
}
