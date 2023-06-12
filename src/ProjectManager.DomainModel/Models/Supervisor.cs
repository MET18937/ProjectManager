using ProjectManager.DomainModel.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectManager.DomainModel.Models
{
    public class Supervisor : EntityBase
    {
        public string? Description { get; set; }
        public int? TeacherId { get; set; }

        //teacher navigation reference
        public int? TeacherNavigationId { get; set; }
        public Teacher Teacher { get; set; } = default!;

        // project list reference
        public List<Project> Projects { get; set; } = new();




        // TDD logic
        public bool IsAssignedToTeacher()
        {
            return TeacherNavigationId != null;
        }

        // constructor
        public Supervisor()
        {
        }

        public Supervisor(string? description, Teacher teacher)
        {
            Description = description;
            Teacher = teacher;
        }
        public Supervisor(int id, string? description, Teacher teacher)
        {
            Id = id;
            Description = description;
            Teacher = teacher;
        }
    }
}
