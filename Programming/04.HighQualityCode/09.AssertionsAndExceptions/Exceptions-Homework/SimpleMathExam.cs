using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }
        private set
        {
            if (!(0 <= value && value <= 2))
            {
                throw new ArgumentOutOfRangeException("The number of the solved problems must be between 0 and 2.");
            }

            this.problemsSolved = value;
        }
    }

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: something done.");
        }
        else
        {
            return new ExamResult(6, 2, 6, "Excelent result: everything done.");
        }
    }
}
