using ProjectManager.DomainModel.Models;

namespace ProjectManager.DomainModel.Models
{
    public class Teacher : EntityBase
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }

        // supervisor reference navigation
        public List<Supervisor> _supervisors { get; set; } = new();
        public virtual IReadOnlyList<Supervisor> Supervisors => _supervisors;


        // TDD logic
        public bool IsAssignedToSupervisor()
        {
            return Supervisors.Count > 0;
        }

        public bool IsAssignedToSupervisor(int supervisorId)
        {
            foreach (var supervisor in Supervisors)
            {
                if (supervisor.Id == supervisorId)
                {
                    return true;
                }
            }
            return false;
        }

        public Teacher()
        {
        }

        public Teacher(string? firstname, string? lastname, string? email)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
        }

        public Teacher(int id, string? firstname, string? lastname, string? email)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
        }
    }
}
