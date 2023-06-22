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
        IEnumerable<StudentDto> GetAll();
        StudentDto GetById(int id);
        void Add(StudentDto student);
        void Update(StudentDto student);
        void Delete(int id);
    }
}
