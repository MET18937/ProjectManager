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
        IEnumerable<Teacher> GetAll();
        Teacher GetById(int id);
        void Add(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(int id);
    }
}
