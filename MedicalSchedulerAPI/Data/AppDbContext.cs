using MedicalschedulerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalschedulerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<user> Users { get; set; }
        public DbSet<role> Roles { get; set; }
        public DbSet<schedule> schedules { get; set; }
        public DbSet<scheduleactivity> scheduleActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<scheduleactivity>().HasNoKey();
        }
    }
}
