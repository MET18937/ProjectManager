using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DomainModel.Models;

namespace ProjectManager.DomainModel.Dtos
{
    public class StudentDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }

        // studentHasProject list reference 
        public List<StudentHasProject> _studentHasProjects { get; set; } = new();
        public virtual IReadOnlyList<StudentHasProject> StudentHasProjects => _studentHasProjects;
    }
}
