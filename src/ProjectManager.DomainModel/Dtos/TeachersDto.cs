using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DomainModel.Models;

namespace ProjectManager.DomainModel.Dtos
{
    public class TeachersDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }

        // supervisor reference navigation
        public List<Supervisor> _supervisors { get; set; } = new();
        public virtual IReadOnlyList<Supervisor> Supervisors => _supervisors;

    }
}
