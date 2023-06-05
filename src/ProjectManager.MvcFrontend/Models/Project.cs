using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.WebApplication.Models
{
	public class Project : EntityBase
	{
		public string? Title { get; set; }
		public string? Description { get; set; }
		public DateTime SubmitDate { get; set; }
        [ForeignKey("Supervisor")]
        public int? SupervisorId { get; set; }
        public Supervisor? Supervisor { get; set; }
        [ForeignKey("Company")]
		public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        // fluent api verwenden
        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
