using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spg.ProjectManager.Application.Models
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

    }
}
