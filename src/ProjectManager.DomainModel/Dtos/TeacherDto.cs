using ProjectManager.DomainModel.Models;

namespace ProjectManager.DomainModel.Models
{
    public class TeacherDto : EntityBaseDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }

        // supervisor reference navigation
        public List<SupervisorDto> Supervisors { get; set; } = new();
    }
}
