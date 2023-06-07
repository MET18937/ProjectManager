using Microsoft.EntityFrameworkCore;
using ProjectManager.ComainModel.Models;

namespace ProjectManager.Infrastructure
{
    public class ProjectManagerContext : DbContext
    {
        // 1. Tabellen Entities mappen
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Company> Companys => Set<Company>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<StudentHasProject> StudentHasProjects => Set<StudentHasProject>();
        public DbSet<Supervisor> Supervisors => Set<Supervisor>();
        public DbSet<Teacher> Teachers => Set<Teacher>();

        // 2. construcotr
        public ProjectManagerContext()
        {
        }

        public ProjectManagerContext(DbContextOptions options) : base(options)
        {
        }

        // 3. Onconfiguring

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=ProjectManager.db");
            }
        }

        // 4. OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // the fluent API way
            modelBuilder.Entity<Company>().HasKey(c => c.Id);
            modelBuilder.Entity<Project>().HasKey(p => p.Id);
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<StudentHasProject>().HasKey(s => s.Id);
            modelBuilder.Entity<Supervisor>().HasKey(s => s.Id);
            modelBuilder.Entity<Teacher>().HasKey(s => s.Id);
        }

        // 5. seeding


    }
}