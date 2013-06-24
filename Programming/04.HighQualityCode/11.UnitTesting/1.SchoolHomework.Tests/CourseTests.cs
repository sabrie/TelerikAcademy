using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolHomework;

[TestClass]
public class CourseTests
{
    [TestMethod]
    public void TestValidAddStudent()
    {
        Course course = new Course();

        course.AddStudent(new Student("Pesho", 50000));
    }

    [TestMethod]
    public void TestValidFullCourse()
    {
        Course course = new Course();

        for (int i = 0; i < 30; i++)
        {
            course.AddStudent(new Student("Pesho", 50000));
        }
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestInvalidFullCourse()
    {
        Course course = new Course();

        for (int i = 0; i < 30 + 1; i++)
        {
            course.AddStudent(new Student("Pesho", 50000));
        }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestDuplicateStudentInCourse()
    {
        Course course = new Course();
        Student student = new Student("Pesho", 50000);

        course.AddStudent(student);
        course.AddStudent(student);
    }
}
