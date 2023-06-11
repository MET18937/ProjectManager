using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DomainModel.Enumerations;

namespace ProjectManager.DomainModel.Models
{
    public class ProjectDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime SubmitDate { get; set; }
        public Projectstates Projectstate { get; set; }

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


    }
}
