using Bogus;
using Microsoft.EntityFrameworkCore;
using ProjectManager.DomainModel.Models;

namespace ProjectManager.Infrastructure
{
    public class ProjectManagerContext : DbContext
    {
        // 1. Tabellen Entities mappen
        public DbSet<CompanyDto> Companies => Set<CompanyDto>();
        public DbSet<TeacherDto> Teachers => Set<TeacherDto>();
        public DbSet<StudentDto> Students => Set<StudentDto>();
        public DbSet<SupervisorDto> Supervisors => Set<SupervisorDto>();
        public DbSet<ProjectDto> Projects => Set<ProjectDto>();
        public DbSet<StudentHasProjectDto> StudentHasProjects => Set<StudentHasProjectDto>();

        // 2. construcotr
        public ProjectManagerContext()
        {
        }

        public ProjectManagerContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            ////fill with data
            //Seed();
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
            modelBuilder.Entity<CompanyDto>().HasKey(c => c.Id);
            modelBuilder.Entity<ProjectDto>().HasKey(p => p.Id);
            modelBuilder.Entity<StudentDto>().HasKey(s => s.Id);
            modelBuilder.Entity<StudentHasProjectDto>().HasKey(s => s.Id);
            modelBuilder.Entity<SupervisorDto>().HasKey(s => s.Id);
            modelBuilder.Entity<TeacherDto>().HasKey(s => s.Id);
        }

        // 5. seeding
        public void Seed()
        {
            Randomizer.Seed = new Random(181025);


            // Company DATA
            List<CompanyDto> companys = new Faker<CompanyDto>("de_AT")
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
            List<StudentDto> students = new Faker<StudentDto>("de_AT")
            .RuleFor(s => s.Firstname, f => f.Name.FirstName())
            .RuleFor(s => s.Lastname, f => f.Name.LastName())
            .RuleFor(s => s.Email, f => f.Internet.Email()).Generate(100).ToList();
            Students.AddRange(students);
            SaveChanges();

            // Teachers DATA
            List<TeacherDto> teachers = new Faker<TeacherDto>("de_AT")
            .RuleFor(t => t.Firstname, f => f.Name.FirstName())
            .RuleFor(t => t.Lastname, f => f.Name.LastName())
            .RuleFor(t => t.Email, f => f.Internet.Email()).Generate(100).ToList();
            Teachers.AddRange(teachers);
            SaveChanges();

            // Supervisor DATA
            // teacher_id t0 random Teacher
            List<SupervisorDto> supervisors = new Faker<SupervisorDto>("de_AT")
                .RuleFor(s => s.TeacherId, f => f.Random.Number(1, teachers.Count))
                .RuleFor(s => s.Description, f => f.Lorem.Paragraph()).Generate(100).ToList();
            Supervisors.AddRange(supervisors);
            SaveChanges();


            // Projects DATA
            List<ProjectDto> projects = new Faker<ProjectDto>("de_AT")
                .RuleFor(p => p.Title, f => f.Name.JobTitle())
                .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
                .RuleFor(p => p.SubmitDate, f => f.Date.Past())
                .RuleFor(p => p.CompanyId, f => f.Random.Number(1, companys.Count))
                .RuleFor(p => p.SupervisorId, f => f.Random.Number(1, supervisors.Count))
                .RuleFor(p => p.TeacherId, f => f.Random.Number(1, teachers.Count)).Generate(100).ToList();
            Projects.AddRange(projects);
            SaveChanges();


            // StudentHasProject DATA
            List<StudentHasProjectDto> studentHasProjects = new Faker<StudentHasProjectDto>("de_AT")
                .RuleFor(s => s.StudentId, f => f.Random.Number(1, students.Count))
                .RuleFor(s => s.ProjectId, f => f.Random.Number(1, projects.Count)).Generate(100).ToList();
            StudentHasProjects.AddRange(studentHasProjects);
            SaveChanges();

        }
    }
}
