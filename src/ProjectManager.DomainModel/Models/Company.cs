using ProjectManager.DomainModel.Models;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.ComainModel.Models
{
    public class Company : EntityBase
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        // project list reference
        public List<Project> _projects { get; set; } = new();
        public virtual IReadOnlyList<Project> Projects => _projects;



        // TDD logic
        public bool IsAssignedToProject()
        {
            return Projects.Count > 0;
        }
        

    }


}
