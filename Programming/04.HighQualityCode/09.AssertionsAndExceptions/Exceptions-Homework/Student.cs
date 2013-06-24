using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("First name is missing or it is not valid!");
            }

            this.firstName = value;
        }
    }
        
    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Last name is missing or it is not valid!");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }
        set
        {
            this.exams = value ?? new List<Exam>();
        }
    }

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public IList<ExamResult> CheckExams()
    {
        return this.Exams.Select(exam => exam.Check()).ToArray();
    }

    public double CalcAverageExamResult()
    {
        double[] examScore = new double[this.Exams.Count];

        IList<ExamResult> examResults = CheckExams();

        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
