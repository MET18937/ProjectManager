using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.DomainModel.Models;

namespace ProjectManager.Infrastructure
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectManagerContext(serviceProvider.GetRequiredService<DbContextOptions<ProjectManagerContext>>()))
            {
                // delete all data 
                context.Database.ExecuteSqlRaw("DELETE FROM StudentHasProject");
                context.Database.ExecuteSqlRaw("DELETE FROM Project");
                context.Database.ExecuteSqlRaw("DELETE FROM Supervisor");
                context.Database.ExecuteSqlRaw("DELETE FROM Teacher");
                context.Database.ExecuteSqlRaw("DELETE FROM Company");
                context.Database.ExecuteSqlRaw("DELETE FROM Student");

                // reset autoincrement
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Company', RESEED, 0)");
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Student', RESEED, 0)");
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Teacher', RESEED, 0)");
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Supervisor', RESEED, 0)");
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Project', RESEED, 0)");
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('StudentHasProject', RESEED, 0)");

                // Company DATA
                var fakerCompany = new Faker<Company>("de_AT")
                    .RuleFor(c => c.Name, f => f.Company.CompanyName())
                    .RuleFor(c => c.Address, f => f.Address.FullAddress())
                    .RuleFor(c => c.Email, f => f.Internet.Email())
                    .RuleFor(c => c.City, f => f.Address.City())
                    .RuleFor(c => c.Region, f => f.Address.State())
                    .RuleFor(c => c.PostalCode, f => f.Address.ZipCode())
                    .RuleFor(c => c.Country, f => f.Address.Country());
                var companies = fakerCompany.Generate(100);
                context.Company.AddRange(companies);
                context.SaveChanges();

                // Student DATA
                var fakerStudent = new Faker<Student>("de_AT")
                .RuleFor(s => s.Firstname, f => f.Name.FirstName())
                .RuleFor(s => s.Lastname, f => f.Name.LastName())
                .RuleFor(s => s.Email, f => f.Internet.Email());
                var students = fakerStudent.Generate(100);
                context.Student.AddRange(students);
                context.SaveChanges();

                // Teachers DATA
                var fakerTeacher = new Faker<Teacher>("de_AT")
                .RuleFor(t => t.Firstname, f => f.Name.FirstName())
                .RuleFor(t => t.Lastname, f => f.Name.LastName())
                .RuleFor(t => t.Email, f => f.Internet.Email());
                var teachers = fakerTeacher.Generate(100);
                context.Teacher.AddRange(teachers);
                context.SaveChanges();

                // Supervisor DATA
                // teacher_id t0 random Teacher
                var fakerSupervisor = new Faker<Supervisor>("de_AT")
                    .RuleFor(s => s.TeacherId, f => f.Random.Number(1, teachers.Count))
                    .RuleFor(s => s.Description, f => f.Lorem.Paragraph());
                var supervisors = fakerSupervisor.Generate(100);
                context.Supervisor.AddRange(supervisors);
                context.SaveChanges();

                // Projects DATA
                var fakerProject = new Faker<Project>("de_AT")
                    .RuleFor(p => p.Title, f => f.Name.JobTitle())
                    .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
                    .RuleFor(p => p.SubmitDate, f => f.Date.Past())
                    .RuleFor(p => p.CompanyId, f => f.Random.Number(1, companies.Count))
                    .RuleFor(p => p.SupervisorId, f => f.Random.Number(1, supervisors.Count))
                    .RuleFor(p => p.TeacherId, f => f.Random.Number(1, teachers.Count));
                var projects = fakerProject.Generate(100);
                context.Project.AddRange(projects);
                context.SaveChanges();

                // StudentHasProject DATA
                var fakerStudentHasProject = new Faker<StudentHasProject>("de_AT")
                    .RuleFor(s => s.StudentId, f => f.Random.Number(1, students.Count))
                    .RuleFor(s => s.ProjectId, f => f.Random.Number(1, projects.Count));
                var studentHasProjects = fakerStudentHasProject.Generate(100);
                context.StudentHasProject.AddRange(studentHasProjects);
                context.SaveChanges();
            }
        }
    }
}
