using ProjectManager.DomainModel.Models;

namespace ProjectManager.Application.Services
{

    public class StudentFilterService
    {
        public string SortOrder { get; set; }

        public StudentFilterService(string sortOrder)
        {
            SortOrder = sortOrder;
        }

        public IQueryable<Student> Apply(IQueryable<Student> students)
        {
            switch (SortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Firstname);
                    break;
                case "LastName":
                    students = students.OrderBy(s => s.Lastname);
                    break;
                case "lastname_desc":
                    students = students.OrderByDescending(s => s.Lastname);
                    break;
                default:
                    students = students.OrderBy(s => s.Firstname);
                    break;
            }
            return students;
        }
    }
}
