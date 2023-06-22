using ProjectManager.DomainModel.Models;

namespace ProjectManager.DomainModel.Models
{
    public class StudentDto : EntityBaseDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }

        // studentHasProject list reference 
        public List<StudentHasProjectDto> StudentHasProjects { get; set; } = new();
    }
}
