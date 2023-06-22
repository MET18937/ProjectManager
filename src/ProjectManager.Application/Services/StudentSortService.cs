using ProjectManager.DomainModel.Models;

namespace ProjectManager.Application.Services
{
    public class StudentSearchService
    {
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }
        public int? PageNumber { get; set; }

        public StudentSearchService(string currentFilter, string searchString, int? pageNumber)
        {
            CurrentFilter = currentFilter;
            SearchString = searchString;
            PageNumber = pageNumber;
        }

        public IQueryable<StudentDto> Apply(IQueryable<StudentDto> students)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                students = students.Where(s => s.Firstname.Contains(SearchString) || s.Lastname.Contains(SearchString) || s.Email.Contains(SearchString));
            }
            return students;
        }
    }
}
