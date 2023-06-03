using System.ComponentModel.DataAnnotations.Schema;

namespace Spg.ProjectManager.Application.Models
{
    public class StudentHasProject
    {
        [ForeignKey("StudentId")]
        public Student? StudentId { get; set; }

        [ForeignKey("ProjectId")]
        public Project? ProjectId { get; set; }

    }
}
