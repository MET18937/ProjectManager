using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DomainModel.Models;

namespace ProjectManager.DomainModel.Interfaces
{
    public interface ITeachersService
    {
        IEnumerable<TeacherDto> GetAll();
        TeacherDto GetById(int id);
        void Add(TeacherDto teacher);
        void Update(TeacherDto teacher);
        void Delete(int id);
    }
}
