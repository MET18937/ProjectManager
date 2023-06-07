using ProjectManager.DomainModel.Models;

namespace ProjectManager.ComainModel.Models
{
    public class Student : EntityBase
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }

        // studentHasProject list reference 
        public List<StudentHasProject> _studentHasProjects { get; set; } = new();
        public virtual IReadOnlyList<StudentHasProject> StudentHasProjects => _studentHasProjects;

        // TDD logic
        public bool IsAssignedToProject()
        {
            return StudentHasProjects.Count > 0;
        }

        public bool IsAssignedToProject(int projectId)
        {
            foreach (var studentHasProject in StudentHasProjects)
            {
                if (studentHasProject.ProjectId == projectId)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
