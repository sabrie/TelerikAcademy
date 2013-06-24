using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public int Grade
    {
        get
        {
            return this.grade;
        }
        private set
        {
            if (!(this.minGrade <= value && value <= this.maxGrade))
            {
                string exMessage = String.Format("Grade should be in the range {0} - {1}", this.minGrade, this.maxGrade);
                throw new ArgumentOutOfRangeException(exMessage);
            }

            this.grade = value;
        }
    }
        
    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }
        private set
        {
            if (value < 0)
            {
                string exMessage = String.Format("Minimal grade should be equal to or bigger than zero");
                throw new ArgumentOutOfRangeException(exMessage);
            }
            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }
        private set
        {
            if (!(value > this.minGrade))
            {
                string exMessage = String.Format("Maximal grade should be bigger than or equal to {0}", this.minGrade);
                throw new ArgumentOutOfRangeException(exMessage);
            }
            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }
        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Comments are null or empty!");
            }

            this.comments = value;
        }
    }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        // Should always be initialized in this order so that we first check if 
        // minGrade and maxGrade parameters are in range
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Grade = grade;
        this.Comments = comments;
    }
}
