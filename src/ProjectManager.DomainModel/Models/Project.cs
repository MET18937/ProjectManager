using ProjectManager.DomainModel.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectManager.ComainModel.Models
{
    public class Project : EntityBase
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime SubmitDate { get; set; }

        // supervisor navigation reference
        public int? SupervisorNavigationId { get; set; }
        public virtual Supervisor SupervisorNavigation { get; set; } = default!;
        // company navigation reference
        public int? CompanyNavigationId { get; set; }
        public virtual Company CompanyNavigation { get; set; } = default!;
        // teacher navigation reference
        public int? TeacherNavigationId { get; set; }
        public virtual Teacher TeacherNavigation { get; set; } = default!;

        // studenthasproject list reference
        public List<StudentHasProject> _studenthasprojects { get; set; } = new();
        public virtual IReadOnlyList<StudentHasProject> StudentHasProjects => _studenthasprojects;

        // TDD logic
        public bool IsSubmitted()
        {
            return SubmitDate < DateTime.Now;
        }

        public bool IsSubmitted(DateTime date)
        {
            return SubmitDate < date;
        }


    }
}
