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

        public StudentService(ProjectManagerContext context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            // Create: mind. 5 Bedingungen (LinQ) prüfen (Bedingungen sollen prüfen, ob ein Datensatz angelegt werden darf)
            // 2. Prüfen, ob der Student Vorname, Nachname und Email hat
            // 3. Prüfen, ob der Student eine gültige Email hat
            // 4. Prüfen, ob der Student Vorname Nachname größer als 2 zeichen hat
            // 5. Prüfen, ob der Student keine leerzeichen am Anfang und am Ende hat, wenn schon dann trimmen

            // 1. Prüfen, ob der Student bereits existiert
            var studentExists = _context.Students.Any(x => x.Email == student.Email);
            if (studentExists)
            {
                throw new System.Exception("Student already exists");
            }
            //2 use linq

            if (_context.Students.Any(s => s.Firstname == null || s.Lastname == null || s.Email == null))
            {
                throw new System.Exception("Student must have a first name, last name and email");
            }

            //3
            if (_context.Students.Any(s => s.Email.Contains("@") == false || s.Email.Contains(".") == false))
            {
                throw new System.Exception("Student must have a valid email");
            }

            //4 
            if (_context.Students.Any(s => s.Firstname.Length < 2 || s.Lastname.Length < 2))
            {
                throw new System.Exception("Student must have a first name and last name with at least 2 characters");
            }

            //5 
            if (_context.Students.Any(s => s.Firstname.Trim() != s.Firstname || s.Lastname.Trim() != s.Lastname))
            {
                throw new System.Exception("Student must not have any spaces at the beginning or end of first name and last name");
            }
            _context.Students.Add(student);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            _context.Students.Remove(GetById(id));
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetAll()
        {
            var data = _context.Students.ToList();
            return data;
        }

        public Student GetById(int id) => _context.Students.Find(id);

        public void Update(Student student)
        {
            // Update: mind. 2 Bedingungen(LinQ) prüfen(Bedingungen sollen prüfen, ob ein Datensatz geändert werden darf)
            // 1. Prüfen, ob der Student existiert
            // 2. Prüfen, ob der neue Student eine gültige Email hat

            //1
            if (_context.Students.Any(s => s.Id != student.Id))
            {
                throw new System.Exception("Student does not exist");
            }

            //2 
            if (student.Email.Contains("@") == false || student.Email.Contains(".") == false)
            {
                throw new System.Exception("Student must have a valid email");
            }

            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
