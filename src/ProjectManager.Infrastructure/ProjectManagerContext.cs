using Bogus;
using Microsoft.EntityFrameworkCore;
using ProjectManager.DomainModel.Models;

namespace ProjectManager.Infrastructure
{
    public class ProjectManagerContext : DbContext
    {
        // 1. Tabellen Entities mappen
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Supervisor> Supervisors => Set<Supervisor>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<StudentHasProject> StudentHasProjects => Set<StudentHasProject>();

        // 2. construcotr
        public ProjectManagerContext()
        {
        }

        public ProjectManagerContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            // fill with data
            Seed();
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
            modelBuilder.Entity<Company>().HasKey(c => c.Id);
            modelBuilder.Entity<Project>().HasKey(p => p.Id);
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<StudentHasProject>().HasKey(s => s.Id);
            modelBuilder.Entity<Supervisor>().HasKey(s => s.Id);
            modelBuilder.Entity<Teacher>().HasKey(s => s.Id);
        }

        // 5. seeding
        public void Seed()
        {
            Randomizer.Seed = new Random(181025);


            // Company DATA
            List<Company> companys = new Faker<Company>("de_AT")
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.Address, f => f.Address.FullAddress())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.Region, f => f.Address.State())
                .RuleFor(c => c.PostalCode, f => f.Address.ZipCode())
                .RuleFor(c => c.Country, f => f.Address.Country())
                .Generate(100).ToList();
            Companies.AddRange(companys);
            SaveChanges();


            // Student DATA
            List<Student> students = new Faker<Student>("de_AT")
            .RuleFor(s => s.Firstname, f => f.Name.FirstName())
            .RuleFor(s => s.Lastname, f => f.Name.LastName())
            .RuleFor(s => s.Email, f => f.Internet.Email()).Generate(100).ToList();
            Students.AddRange(students);
            SaveChanges();

            // Teachers DATA
            List<Teacher> teachers = new Faker<Teacher>("de_AT")
            .RuleFor(t => t.Firstname, f => f.Name.FirstName())
            .RuleFor(t => t.Lastname, f => f.Name.LastName())
            .RuleFor(t => t.Email, f => f.Internet.Email()).Generate(100).ToList();
            Teachers.AddRange(teachers);
            SaveChanges();

            // Supervisor DATA
            // teacher_id t0 random Teacher
            List<Supervisor> supervisors = new Faker<Supervisor>("de_AT")
                .RuleFor(s => s.TeacherId, f => f.Random.Number(1, teachers.Count))
                .RuleFor(s => s.Description, f => f.Lorem.Paragraph()).Generate(100).ToList();
            Supervisors.AddRange(supervisors);
            SaveChanges();


            // Projects DATA
            List<Project> projects = new Faker<Project>("de_AT")
                .RuleFor(p => p.Title, f => f.Name.JobTitle())
                .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
                .RuleFor(p => p.SubmitDate, f => f.Date.Past())
                .RuleFor(p => p.CompanyId, f => f.Random.Number(1, companys.Count))
                .RuleFor(p => p.SupervisorId, f => f.Random.Number(1, supervisors.Count))
                .RuleFor(p => p.TeacherId, f => f.Random.Number(1, teachers.Count)).Generate(100).ToList();
            Projects.AddRange(projects);
            SaveChanges();


            // StudentHasProject DATA
            List<StudentHasProject> studentHasProjects = new Faker<StudentHasProject>("de_AT")
                .RuleFor(s => s.StudentId, f => f.Random.Number(1, students.Count))
                .RuleFor(s => s.ProjectId, f => f.Random.Number(1, projects.Count)).Generate(100).ToList();
            StudentHasProjects.AddRange(studentHasProjects);
            SaveChanges();

        }
    }
}
