using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.WebApplication.Models
{
    public class Supervisor : EntityBase
    {
        public string? Description { get; set; }

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

    }
}
