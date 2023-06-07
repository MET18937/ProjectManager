using ProjectManager.DomainModel.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectManager.ComainModel.Models
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



    }
}
