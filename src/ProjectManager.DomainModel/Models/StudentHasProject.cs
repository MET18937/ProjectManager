using ProjectManager.DomainModel.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectManager.DomainModel.Models
{
    public class StudentHasProject : EntityBase
    {
        // student navigation reference
        public int? StudentId { get; set; }
        public  Student Student { get; set; } = default!;

        // project navigation reference
        public int? ProjectId { get; set; }
        public  Project Project { get; set; } = default!;



        // TDD logic
        public bool IsAssignedToStudent()
        {
            return StudentId != null;
        }

        public bool IsAssignedToProject()
        {
            return ProjectId != null;
        }

        // constructor
        public StudentHasProject()
        {
        }

        public StudentHasProject(Student student, Project project)
        {
            Student = student;
            Project = project;
        }

        public StudentHasProject(int id, Student student, Project project)
        {
            Id = id;
            Student = student;
            Project= project;
        }


    }
}
