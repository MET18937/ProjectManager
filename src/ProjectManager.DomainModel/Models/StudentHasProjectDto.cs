using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DomainModel.Models
{
    public class StudentHasProjectDto
    {
        // student navigation reference
        public int? StudentNavigationId { get; set; }
        public virtual Student StudentNavigation { get; set; } = default!;

        // project navigation reference
        public int? ProjectNavigationId { get; set; }
        public virtual Project ProjectNavigation { get; set; } = default!;


    }
}
