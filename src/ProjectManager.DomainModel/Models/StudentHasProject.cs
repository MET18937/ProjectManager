using ProjectManager.DomainModel.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectManager.ComainModel.Models
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







    }
}
