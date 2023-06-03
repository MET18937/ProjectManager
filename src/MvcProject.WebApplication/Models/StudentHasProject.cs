using System.ComponentModel.DataAnnotations.Schema;

namespace Spg.ProjectManager.Application.Models
{
    public class StudentHasProject : EntityBase
    {
        [ForeignKey("Student")]
        public int? StudentId { get; set; }

        [ForeignKey("Project")]
        public int? ProjectId { get; set; }

    }
}
