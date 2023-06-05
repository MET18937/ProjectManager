using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.WebApplication.Models
{
    public class StudentHasProject : EntityBase
    {
        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        public Student? Student { get; set; }


        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }

    }
}
