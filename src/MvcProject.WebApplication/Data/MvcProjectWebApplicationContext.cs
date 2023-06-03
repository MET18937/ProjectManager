using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spg.ProjectManager.Application.Models;

namespace MvcProject.WebApplication.Data
{
    public class MvcProjectWebApplicationContext : DbContext
    {
        public MvcProjectWebApplicationContext (DbContextOptions<MvcProjectWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Spg.ProjectManager.Application.Models.Company> Company { get; set; } = default!;
    }
}
