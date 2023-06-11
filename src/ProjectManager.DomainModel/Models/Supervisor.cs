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
        public virtual Teacher TeacherNavigation { get; set; } = default!;

        // TDD logic
        public bool IsAssignedToTeacher()
        {
            return TeacherNavigationId != null;
        }

        // constructor
        public Supervisor()
        {
        }

        public Supervisor(string? description, Teacher teacherNavigation)
        {
            Description = description;
            TeacherNavigation = teacherNavigation;
        }
        public Supervisor(int id, string? description, Teacher teacherNavigation)
        {
            Id = id;
            Description = description;
            TeacherNavigation = teacherNavigation;
        }
    }
}
