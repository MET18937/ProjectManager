using System.ComponentModel.DataAnnotations.Schema;

namespace Spg.ProjectManager.Application.Models
{
	public class Project : EntityBase
	{
		public string? Title { get; set; }
		public string? Description { get; set; }
		public DateTime SubmitDate { get; set; }
        [ForeignKey("Supervisor")]
        public int? SupervisorId { get; set; }
        [ForeignKey("Company")]
		public int? CompanyId { get; set; }
        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
    }
}
