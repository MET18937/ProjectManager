using System.ComponentModel.DataAnnotations.Schema;

namespace Spg.ProjectManager.Application.Models
{
    public class Supervisor : EntityBase
    {
        // foreign key from table teacher
        [ForeignKey("TeacherId")]
        public Teacher? TeacherId { get; set; }
        public string? Description { get; set; }

    }
}
