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

        public void Add(TeacherDto teacher)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<TeacherDto> GetAll()
        {
            var data =  _context.Teachers.ToList();
            return data;
        }

        public TeacherDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TeacherDto teacher)
        {
            throw new NotImplementedException();
        }

       
    }
}
