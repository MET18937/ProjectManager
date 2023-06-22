using ProjectManager.DomainModel.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectManager.DomainModel.Models
{
    public class ProjectDto : EntityBaseDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime SubmitDate { get; set; }
        public Projectstates Projectstate { get; set; }

        // supervisor navigation reference
        public int? SupervisorId { get; set; }
        public SupervisorDto Supervisor { get; set; } = default!;

        // company navigation reference
        public int? CompanyId { get; set; }
        public CompanyDto Company { get; set; } = default!;

        // teacher navigation reference
        public int? TeacherId { get; set; }
        public TeacherDto Teacher { get; set; } = default!;

        // studenthasproject list reference
        public List<StudentHasProjectDto> Studenthasprojects { get; set; } = new();
    }
}
