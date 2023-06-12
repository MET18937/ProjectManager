using ProjectManager.DomainModel.Models;

namespace ProjectManager.DomainModel.Models
{
    public class Student : EntityBase
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }

        // studentHasProject list reference 
        public List<StudentHasProject> StudentHasProjects { get; set; } = new();




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
