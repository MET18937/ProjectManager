using ProjectManager.DomainModel.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectManager.DomainModel.Models
{
    public class StudentHasProjectDto : EntityBaseDto
    {
        // student navigation reference
        public int? StudentId { get; set; }
        public  StudentDto Student { get; set; } = default!;

        // project navigation reference
        public int? ProjectId { get; set; }
        public  ProjectDto Project { get; set; } = default!;
    }
}
