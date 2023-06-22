using ProjectManager.DomainModel.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectManager.DomainModel.Models
{
    public class SupervisorDto : EntityBaseDto
    {
        public string? Description { get; set; }
        public int? TeacherId { get; set; }

        //teacher navigation reference
        public int? TeacherNavigationId { get; set; }
        public TeacherDto Teacher { get; set; } = default!;

        // project list reference
        public List<ProjectDto> Projects { get; set; } = new();
    }
}
