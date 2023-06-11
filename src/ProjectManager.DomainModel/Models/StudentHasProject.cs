using ProjectManager.DomainModel.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectManager.DomainModel.Models
{
    public class StudentHasProject : EntityBase
    {
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

        public StudentHasProject(Student studentNavigation, Project projectNavigation)
        {
            StudentNavigation = studentNavigation;
            ProjectNavigation = projectNavigation;
        }

        public StudentHasProject(int id, Student studentNavigation, Project projectNavigation)
        {
            Id = id;
            StudentNavigation = studentNavigation;
            ProjectNavigation = projectNavigation;
        }


    }
}
