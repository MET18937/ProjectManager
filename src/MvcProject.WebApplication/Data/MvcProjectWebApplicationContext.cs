using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcProject.WebApplication.Models;

namespace MvcProject.WebApplication.Data
{
    public class MvcProjectWebApplicationContext : DbContext
    {
        public MvcProjectWebApplicationContext (DbContextOptions<MvcProjectWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<MvcProject.WebApplication.Models.Teacher> Teacher { get; set; } = default!;

        public DbSet<MvcProject.WebApplication.Models.Company> Company { get; set; } = default!;

        public DbSet<MvcProject.WebApplication.Models.Student> Student { get; set; } = default!;

        public DbSet<MvcProject.WebApplication.Models.Supervisor> Supervisor { get; set; } = default!;

        public DbSet<MvcProject.WebApplication.Models.Project> Project { get; set; } = default!;

        public DbSet<MvcProject.WebApplication.Models.StudentHasProject> StudentHasProject { get; set; } = default!;
    }
}
