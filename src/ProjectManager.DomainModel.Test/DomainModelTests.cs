using Microsoft.EntityFrameworkCore;
using ProjectManager.DomainModel.Models;
using ProjectManager.DomainModel.Enumerations;
using ProjectManager.Infrastructure;
namespace ProjectManager.DomainModel.Test

{
    public class DomainModelTests
    {
        private ProjectManagerContext CreateDb()
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.UseSqlite("Data Source=ProjectManager_Test.db");
            ProjectManagerContext db = new ProjectManagerContext(options.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            //db.Seed();
            return db;
        }

        [Fact]
        public void SeedDb()
        {
            ProjectManagerContext db = CreateDb();
            db.Seed();
        }


        // Tripple A-Pattern AAA
        [Fact]
        public void Company_Add_SuccessTest()
        {
            // 1. Arrange
            ProjectManagerContext db = CreateDb();
            Company newCompany = new Company("Testfirma", "Teststrasse 1", "testfirma@example.com", "Teststadt", "Testregion", "12345", "Testland");

            // 2. Act
            db.Companys.Add(newCompany);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.Companys.Count());
        }



        [Fact]
        public void Student_Add_SuccessTest()
        {

            // 1. Arrange
            ProjectManagerContext db = CreateDb();
            Student newStudent = new Student("Testvorname", "Testnachname", "teststudent@example.com");

            // 2. Act
            db.Students.Add(newStudent);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.Students.Count());
        }

        [Fact]
        public void Teacher_Add_SuccessTest()
        {
            // 1. Arrange
            ProjectManagerContext db = CreateDb();
            Teacher newTeacher = new Teacher("Testvorname", "Testnachname", "teacher@example.com");

            // 2. Act
            db.Teachers.Add(newTeacher);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.Teachers.Count());
        }

        [Fact]
        public void Supervisor_Add_SuccessTest()
        {
            // 1. Arrange
            ProjectManagerContext db = CreateDb();
            Supervisor newSupervisor = new Supervisor("Beschreibung", null);

            // 2. Act
            db.Supervisors.Add(newSupervisor);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.Supervisors.Count());
        }

        [Fact]
        public void Project_Add_SuccessTest()
        {
            // 1. Arrange
            ProjectManagerContext db = CreateDb();
            // datetime example
            Project newProject = new Project("Testprojekt", "Testbeschreibung", new DateTime(2019, 10, 25), Projectstates.Active, null, null, null);

            // 2. Act
            db.Projects.Add(newProject);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.Projects.Count());
        }

        [Fact]
        public void StudentHasProject_Add_SuccessTest()
        {
            // 1. Arrange
            ProjectManagerContext db = CreateDb();
            StudentHasProject newStudentHasProject = new StudentHasProject(null, null);

            // 2. Act
            db.StudentHasProjects.Add(newStudentHasProject);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.StudentHasProjects.Count());

        }
    }
}
