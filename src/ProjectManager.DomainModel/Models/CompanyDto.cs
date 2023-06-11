using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DomainModel.Models
{
    public class CompanyDto
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

    }
}
