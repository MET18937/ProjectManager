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

        public Supervisor(string? description, int? teacherId, int? teacherNavigationId, Teacher teacherNavigation)
        {
            Description = description;
            TeacherId = teacherId;
            TeacherNavigationId = teacherNavigationId;
            TeacherNavigation = teacherNavigation;
        }
    }
}
