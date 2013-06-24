using System;
using SchoolHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SchoolTests
{
    [TestMethod]
    public void TestAddValidStudent()
    {
        School school = new School();

        school.AddStudent(new Student("Pesho", 50000));
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestAddDuplicateStudentId()
    {
        School school = new School();

        school.AddStudent(new Student("Pesho", 50000));
        school.AddStudent(new Student("Pesho", 50000));
    }
}
