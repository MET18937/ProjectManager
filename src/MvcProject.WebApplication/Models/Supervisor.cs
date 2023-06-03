using System.ComponentModel.DataAnnotations.Schema;

namespace Spg.ProjectManager.Application.Models
{
    public class Supervisor : EntityBase
    {
        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public string? Description { get; set; }

    }
}
