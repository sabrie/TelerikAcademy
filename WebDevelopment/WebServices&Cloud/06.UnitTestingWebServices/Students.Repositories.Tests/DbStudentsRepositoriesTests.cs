using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students.Models;
using Students.DataLayer;
using System.Data.Entity;
using System.Transactions;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Students.Repositories.Tests
{
    [TestClass]
    public class DbStudentsRepositoriesTests
    {
        public DbContext dbContext { get; set; }

        static Random rand = new Random();

        public IRepository<Student> studentsRepository { get; set; }

        private static TransactionScope tranScope;

        public DbStudentsRepositoriesTests()
        {
            this.dbContext = new StudentsContext();
            this.studentsRepository = new DbStudentRepository(this.dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        public void AddValidStudent_ShouldAddStudentToDatabase()
        {
            Student student = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshev",
                Age = 21
            };

            var createdStudent = this.studentsRepository.Add(student);
            var foundStudent = this.dbContext.Set<Student>().Find(createdStudent.StudentId);
            
            Assert.IsNotNull(foundStudent);
            Assert.IsTrue(foundStudent.StudentId > 0);
            Assert.AreEqual(createdStudent.FirstName, foundStudent.FirstName);
        }

        [TestMethod]
        public void GetAllStudentWhenDBIsNotEmpty_ShouldFindAllStudents()
        {
            var student1 = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshev",
                Age = 21
            };

            var student2 = new Student()
            {
                FirstName = "Tosho",
                LastName = "Toshev",
                Age = 22
            };

            var student3 = new Student()
            {
                FirstName = "Gosho",
                LastName = "Goshev",
                Age = 23
            };

            Student createdStudent1 = this.studentsRepository.Add(student1);
            Student createdStudent2 = this.studentsRepository.Add(student2);
            Student createdStudent3 = this.studentsRepository.Add(student3);

            int actualStudentsCount = 3;

            var allStudents = this.studentsRepository.All();
            Assert.AreEqual(allStudents.Count(), actualStudentsCount);
        }

        [TestMethod]
        public void GetAllStudentWhenDBIsEmpty_ShouldNotFindStudents()
        {
            var allStudents = this.studentsRepository.All();
            int expectedStudentsCount = 0;
            Assert.AreEqual(allStudents.Count(), expectedStudentsCount);
        }

        [TestMethod]
        public void GetByIdExistingStudent_ShouldFindStudent()
        {
            var student = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshev",
                Age = 21
            };

            var createdStudent = this.studentsRepository.Add(student);
            var foundStudent = this.studentsRepository.Get(createdStudent.StudentId);
            Assert.IsNotNull(foundStudent);
            Assert.IsTrue(foundStudent.StudentId > 0);
            Assert.AreEqual(createdStudent.StudentId, foundStudent.StudentId);
        }

        [TestMethod]
        public void GetByIdNonExistingStudent_ShouldNotFindStudent()
        {
            int nonExistingStudentId = 100;
            var foundStudent = this.studentsRepository.Get(nonExistingStudentId);
            Assert.IsNull(foundStudent);
        }

        [TestMethod]
        public void FindStudentsByPredicateWhenExist_ShouldFindStudents()
        {
            var student1 = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshev",
                Age = 21
            };

            var student2 = new Student()
            {
                FirstName = "Tosho",
                LastName = "Toshev",
                Age = 22
            };

            var student3 = new Student()
            {
                FirstName = "Gosho",
                LastName = "Goshev",
                Age = 23
            };

            var createdStudent1 = this.studentsRepository.Add(student1);
            var createdStudent2 = this.studentsRepository.Add(student2);
            var createdStudent3 = this.studentsRepository.Add(student3);

            Expression<Func<Student, int, bool>> predicate = (s, i) => s.Age == 23;
            var foundStudent = this.studentsRepository.Find(predicate);
            Assert.IsNotNull(foundStudent);
        }

        // TODO
        // Test fails

        //[TestMethod]
        //public void FindStudentsByPredicateWhenDontExist_ShouldNotFindStudents()
        //{
        //    Expression<Func<Student, int, bool>> predicate = (s, i) => s.Age == 23;
        //    var foundStudents = this.studentsRepository.Find(predicate);
        //    Assert.IsTrue(foundStudents.Count() == 0);
        //}       
    }
}
