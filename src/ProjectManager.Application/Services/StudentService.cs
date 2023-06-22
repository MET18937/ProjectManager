using ProjectManager.DomainModel.Models;
using ProjectManager.DomainModel.Interfaces;
using ProjectManager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using static Bogus.DataSets.Name;

namespace ProjectManager.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly ProjectManagerContext _context;

        //private readonly IRepositoryBase<Student> _studentRepository;
        //private readonly IReadOnlyRepositoryBase<Student> _studentReadOnlyRepository;

        public StudentService(ProjectManagerContext context)
        {
            _context = context;
        }

        //public StudentService(IRepositoryBase<Student> studentRepository, IReadOnlyRepositoryBase<Student> studentReadOnlyRepository)
        //{
        //    _studentRepository = studentRepository;
        //    _studentReadOnlyRepository = studentReadOnlyRepository;
        //}


        public void Add(StudentDto student)
        {
            // Create: mind. 5 Bedingungen (LinQ) prüfen (Bedingungen sollen prüfen, ob ein Datensatz angelegt werden darf)
            // 1. Prüfen, ob der Student bereits existiert
            if (_context.Students.Any(x => x.Email == student.Email))
                throw new System.Exception("Student already exists");

            // 2. Prüfen, ob der Student Vorname, Nachname und Email hat
            if (student.Firstname == null || student.Lastname == null || student.Email == null)
                throw new System.Exception("Student must have a first name, last name and email");

            // 3. Prüfen, ob der Student eine gültige Email hat
            if (student.Email.Contains("@") == false || student.Email.Contains(".") == false)
                throw new System.Exception("Student must have a valid email");

            // 4. Prüfen, ob der Student Vorname Nachname größer als 2 zeichen hat
            if (student.Firstname.Length < 2 || student.Lastname.Length < 2)
                throw new System.Exception("Student must have a first name and last name with at least 2 characters");

            // 5. Prüfen, ob der Student keine leerzeichen am Anfang und am Ende hat, wenn schon dann trimmen
            if (student.Firstname.Trim() != student.Firstname || student.Lastname.Trim() != student.Lastname)
                throw new System.Exception("Student must not have any spaces at the beginning or end of first name and last name");

            _context.Students.Add(student);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            _context.Students.Remove(GetById(id));
            _context.SaveChanges();
        }

        public IEnumerable<StudentDto> GetAll()
        {
            var data = _context.Students.ToList();
            return data;
        }

        public StudentDto GetById(int id) => _context.Students.Find(id);

        public void Update(StudentDto student)
        {
            // Update: mind. 2 Bedingungen(LinQ) prüfen(Bedingungen sollen prüfen, ob ein Datensatz geändert werden darf)

            // 1. Prüfen, ob der neue Student nicht null ist
            if (student == null)
                throw new System.Exception("Student does not exist");

            // 2. Prüfen, ob der neue Student Vorname, Nachname und Email nicht null oder " " ist
            if (student.Firstname == null || student.Lastname == null || student.Email == null)
                throw new System.Exception("Student must have a first name, last name and email");

            // 3. Prüfen, ob der neue Student eine gültige Email hat
            if (student.Email.Contains("@") == false || student.Email.Contains(".") == false)
                throw new System.Exception("Student must have a valid email");

            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
