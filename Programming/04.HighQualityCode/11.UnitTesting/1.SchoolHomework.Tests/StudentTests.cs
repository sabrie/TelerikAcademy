using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolHomework;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void TestValidStudent()
    {
        new Student("Pesho", 50000);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestNullName()
    {
        new Student(null, 50000);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestEmptyName()
    {
        new Student("", 50000);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestInvalidIdLowRange()
    {
        new Student("Pesho", 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestInvalidIdLowRangeLimit()
    {
        new Student("Pesho", 10000 - 1);
    }

    [TestMethod]
    public void TestValidIdLowRangeLimit()
    {
        new Student("Pesho", 10000);
    }

    [TestMethod]
    public void TestValidIdHighRangeLimit()
    {
        new Student("Pesho", 99999);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestInvalidIdHighRangeLimit()
    {
        new Student("Pesho", 99999 + 1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestInvalidIdHighRange()
    {
        new Student("Pesho", 500000);
    }
}
