using ProjectManager.DomainModel.Models;
using ProjectManager.DomainModel.Interfaces;
using ProjectManager.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly ProjectManagerContext _context;

        public StudentService(ProjectManagerContext context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            var data = _context.Students.ToList();
            return data;
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
