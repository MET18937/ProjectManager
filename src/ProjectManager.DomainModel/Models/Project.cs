using ProjectManager.DomainModel.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectManager.DomainModel.Models
{
    public class Project : EntityBase
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime SubmitDate { get; set; }
        public Projectstates Projectstate { get; set; }

        // supervisor navigation reference
        public int? SupervisorId { get; set; }
        public Supervisor Supervisor { get; set; } = default!;

        // company navigation reference
        public int? CompanyId { get; set; }
        public Company Company { get; set; } = default!;

        // teacher navigation reference
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; } = default!;

        // studenthasproject list reference
        public List<StudentHasProject> Studenthasprojects { get; set; } = new();

        // TDD logic
        public bool IsSubmitted()
        {
            return SubmitDate < DateTime.Now;
        }

        public bool IsSubmitted(DateTime date)
        {
            return SubmitDate < date;
        }


        public Project()
        {
        }

        public Project(string? title, string? description, DateTime submitDate, Projectstates projectstate, Supervisor supervisor, Company company, Teacher teacher)
        {
            Title = title;
            Description = description;
            SubmitDate = submitDate;
            Projectstate = projectstate;
            Supervisor = supervisor;
            Company = company;
            Teacher = teacher;
        }
        public Project(int id, string? title, string? description, DateTime submitDate, Projectstates projectstate, Supervisor supervisor, Company company, Teacher teacher)
        {
            Id = id;
            Title = title;
            Description = description;
            SubmitDate = submitDate;
            Projectstate = projectstate;
            Supervisor = supervisor;
            Company = company;
            Teacher = teacher;
        }
        public Project(int id, string? title, string? description, DateTime submitDate, Projectstates projectstate, Supervisor supervisor, Company company, Teacher teacher, List<StudentHasProject> studenthasprojects)
        {
            Id = id;
            Title = title;
            Description = description;
            SubmitDate = submitDate;
            Projectstate = projectstate;
            Supervisor = supervisor;
            Company = company;
            Teacher = teacher;
            Studenthasprojects = studenthasprojects;
        }
    }
}
