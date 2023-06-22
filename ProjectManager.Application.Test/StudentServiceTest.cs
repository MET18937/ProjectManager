using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Services;
using ProjectManager.DomainModel.Interfaces;
using ProjectManager.DomainModel.Models;
using ProjectManager.Infrastructure;
using Xunit;

namespace ProjectManager.Application.Test
{
    public class StudentServiceTest
    {
        private ProjectManagerContext CreateDb()
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.UseSqlite("Data Source=ProjectManager_Test.db");
            ProjectManagerContext db = new ProjectManagerContext(options.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }
        [Fact]
        public void Add_SuccessTest()
        {
            // Arrange
            ProjectManagerContext db = CreateDb();
            Student student = new Student
            {
                Firstname = "Maxi",
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };

            StudentService studentService = new StudentService(db);

            // Act
            studentService.Add(student);

            // Assert
            Assert.Equal(1, db.Students.Count());
        }
        [Fact]
        public void Delete_SuccessTest()
        {
            // Arrange
            ProjectManagerContext db = CreateDb();
            Student student = new Student
            {
                Firstname = "Maxi",
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };
            StudentService studentService = new StudentService(db);

            // Act
            studentService.Add(student);
            studentService.Delete(1);

            // Assert
            Assert.Equal(0, db.Students.Count());
        }
        [Fact]
        public void Update_SuccessTest()
        {
            // arrange
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);

            Student oldStudent = new Student
            {
                Firstname = "Maxi",
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };
            studentService.Add(oldStudent);

            Student newStudent = studentService.GetById(1);
            newStudent.Firstname = "Hansi";
            newStudent.Lastname = "Müller";

            // act
            studentService.Update(newStudent);

            // assert
            Assert.Equal("Hansi", newStudent.Firstname); // new
            Assert.Equal("Müller", newStudent.Lastname); // new
            Assert.Equal("MaxiMusti@uni.com", newStudent.Email); // old
        }
        [Fact]
        public void ReadAll_SuccessTest()
        {
            // arrange
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);

            Student student = new Student
            {
                Firstname = "Maxi",
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };
            studentService.Add(student);

            // act
            IQueryable<StudentDto> students = studentService.GetAll();

            // assert
            Assert.Equal(1, students.Count());

        }
        [Fact]
        public void ReadId_SuccessTest()
        {
            // arrange
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);

            Student student = new Student
            {
                Firstname = "Maxi",
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };
            studentService.Add(student);

            // act
            Student readStudent = studentService.GetById(1);

            // assert
            Assert.Equal("Maxi", readStudent.Firstname);
            Assert.Equal("Mustermann", readStudent.Lastname);
            Assert.Equal("MaxiMusti@uni.com", readStudent.Email);
        }

        // Add Tests
        // trigger exceptions
        //1 email check
        [Fact]
        public void Add_EmailAlreadyExists_ThrowsException()
        {
            // arrange
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);

            Student student = new Student
            {
                Firstname = "Maxi",
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };

            // act
            studentService.Add(student);

            // assert
            Assert.Throws<Exception>(() => studentService.Add(student));
        }

        //2 if firstname is null
        [Fact]
        public void Add_FirstnameIsNull_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);

            Student student = new Student
            {
                Firstname = null,
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };

            Assert.Throws<Exception>(() => studentService.Add(student));
        }
        [Fact]
        public void Add_LastnameIsNull_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);

            Student student = new Student
            {
                Firstname = "Maxi",
                Lastname = null,
                Email = "MaxiMusti@uni.com"
            };

            Assert.Throws<Exception>(() => studentService.Add(student));
        }

        [Fact]
        public void Add_EmailIsNull_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);

            Student student = new Student
            {
                Firstname = "Maxi",
                Lastname = "Mustermann",
                Email = null
            };

            Assert.Throws<Exception>(() => studentService.Add(student));
        }

        //3if email is not valid
        [Fact]
        public void Add_EmailIsNotValid_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);

            Student student = new Student
            {
                Firstname = "Maxi",
                Lastname = "Mustermann",
                Email = "MaxiMustiuni.com"
            };

            Assert.Throws<Exception>(() => studentService.Add(student));
        }

        // if firstname or lastname too short
        [Fact]
        public void Add_FirstnameTooShort_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);

            Student student = new Student
            {
                Firstname = "M",
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };

            Assert.Throws<Exception>(() => studentService.Add(student));
        }

        [Fact]
        public void Add_LastnameTooShort_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);

            Student student = new Student
            {
                Firstname = "Maxi",
                Lastname = "M",
                Email = "MaxiMusti@uni.com"
            };

            Assert.Throws<Exception>(() => studentService.Add(student));
        }

        // 5 if space on front or back
        [Fact]
        public void Add_FirstnameSpaceOnFront_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);

            Student student = new Student
            {
                Firstname = " Maxi",
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };

            Assert.Throws<Exception>(() => studentService.Add(student));
        }
        [Fact]
        public void Add_FirstnameSpaceOnBack_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);
            Student student = new Student
            {
                Firstname = "Maxi ",
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };

            Assert.Throws<Exception>(() => studentService.Add(student));
        }

        // invalid update tests trigger exceptions
        //1 if student is null
        [Fact]
        public void Update_StudentIsNull_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);

            Assert.Throws<Exception>(() => studentService.Update(null));
        }
        //2
        [Fact]
        public void Update_EmailIsNotValid_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);
            Student student1 = new Student
            {
                Firstname = "Maxi",
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };
            studentService.Add(student1);

            Student student2 = studentService.GetById(student1.Id);
            student2.Email = "MaxiMustiuni.com";

            Assert.Throws<Exception>(() => studentService.Update(student2));
        }

        //3 if firstname or lastname or email is null
        [Fact]
        public void Update_FirstnameIsNull_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);
            Student student1 = new Student
            {
                Firstname = "Max",
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };
            studentService.Add(student1);

            Student student2 = studentService.GetById(student1.Id);
            student2.Firstname = null;

            Assert.Throws<Exception>(() => studentService.Update(student2));
        }
        [Fact]
        public void Update_LastnameIsNull_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);
            Student student1 = new Student
            {
                Firstname = "Maxi",
                Lastname = "Must",
                Email = "MaxiMusti@uni.com"
            };
            studentService.Add(student1);

            Student student2 = studentService.GetById(student1.Id);
            student2.Lastname = null;

            Assert.Throws<Exception>(() => studentService.Update(student2));
        }
        [Fact]
        public void Update_EmailIsNull_ThrowsException()
        {
            ProjectManagerContext db = CreateDb();
            StudentService studentService = new StudentService(db);
            Student student1 = new Student
            {
                Firstname = "Maxi",
                Lastname = "Mustermann",
                Email = "MaxiMusti@uni.com"
            };
            studentService.Add(student1);

            Student student2 = studentService.GetById(student1.Id);
            student2.Email = null;

            Assert.Throws<Exception>(() => studentService.Update(student2));
        }
    }
}
