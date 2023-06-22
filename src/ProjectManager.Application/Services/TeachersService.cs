using ProjectManager.DomainModel.Models;
using ProjectManager.DomainModel.Interfaces;
using ProjectManager.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Application.Services
{
    public class TeachersService : ITeachersService
    {
        private readonly ProjectManagerContext _context;
        public TeachersService(ProjectManagerContext context)
        {
            _context = context;
        }

        public void Add(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TeacherDto> GetAll()
        {
            return _context.Teachers.Select(t => new TeacherDto
            {
                Id = t.Id,
                Firstname = t.Firstname,
                Lastname = t.Lastname,
                Email = t.Email,
            });
        }

        public Teacher GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Teacher teacher)
        {
            throw new NotImplementedException();
        }


    }
}
