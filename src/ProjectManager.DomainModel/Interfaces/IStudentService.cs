using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DomainModel.Models;

namespace ProjectManager.DomainModel.Interfaces
{
    public interface IStudentService
    {
        IQueryable<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
    }
}
