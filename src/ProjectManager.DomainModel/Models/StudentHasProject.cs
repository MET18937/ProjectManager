using ProjectManager.DomainModel.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectManager.DomainModel.Models
{
    public class StudentHasProject : EntityBase
    {
        public int? StudentId { get; set; }
        public int? ProjectId { get; set; }

        // student navigation reference
        public int? StudentNavigationId { get; set; }
        public virtual Student StudentNavigation { get; set; } = default!;

        // project navigation reference
        public int? ProjectNavigationId { get; set; }
        public virtual Project ProjectNavigation { get; set; } = default!;



        // TDD logic
        public bool IsAssignedToStudent()
        {
            return StudentNavigationId != null;
        }

        public bool IsAssignedToProject()
        {
            return ProjectNavigationId != null;
        }

        // constructor
        public StudentHasProject()
        {
        }

        public StudentHasProject(int? studentId, int? projectId, int? studentNavigationId, Student studentNavigation, int? projectNavigationId, Project projectNavigation)
        {
            StudentId = studentId;
            ProjectId = projectId;
            StudentNavigationId = studentNavigationId;
            StudentNavigation = studentNavigation;
            ProjectNavigationId = projectNavigationId;
            ProjectNavigation = projectNavigation;
        }
    }
}
