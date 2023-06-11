using ProjectManager.DomainModel.Models;

namespace ProjectManager.DomainModel.Models
{
    public class Student : EntityBase
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }

        // studentHasProject list reference 
        public List<StudentHasProject> _studentHasProjects { get; set; } = new();
        public virtual IReadOnlyList<StudentHasProject> StudentHasProjects => _studentHasProjects;


        // get all project that are assigned to student
        public List<Project> GetProjects()
        {
            List<Project> projects = new();
            foreach (var studentHasProject in StudentHasProjects)
            {
                projects.Add(studentHasProject.ProjectNavigation);
            }
            return projects;
        }


        public Student()
        {
        }

        public Student(string? firstname, string? lastname, string? email)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
        }

        public Student(int id, string? firstname, string? lastname, string? email)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
        }
    }
}
