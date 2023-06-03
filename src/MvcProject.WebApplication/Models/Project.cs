using System.ComponentModel.DataAnnotations.Schema;

namespace Spg.ProjectManager.Application.Models
{
	public class Project : EntityBase
	{
		public string? Title { get; set; }
		public string? Description { get; set; }
		public DateTime SubmitDate { get; set; }
		[ForeignKey("CompanyId")]
		public Company? CompanyId { get; set; }
		[ForeignKey("TeacherId")]
		public Teacher? TeacherId { get; set; }
		[ForeignKey("SupervisorId")]
		public Supervisor? SupervisorId { get; set; }
	}
}
