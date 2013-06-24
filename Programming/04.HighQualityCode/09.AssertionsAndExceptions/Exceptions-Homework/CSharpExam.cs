using System;

public class CSharpExam : Exam
{
    private const int MinScore = 0;
    private const int MaxScore = 100;

    private int score;
    
    public int Score
    {
        get
        {
            return this.score;
        }
        private set
        {
            if (!(MinScore <= value && value <= MaxScore))
            {
                string exMessage = String.Format("The exam score must be in the range {0} - {1}", MinScore, MaxScore);
                throw new ArgumentOutOfRangeException(exMessage);
            }

            this.score = value;
        }
    }

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, MinScore, MaxScore, "Exam results calculated by score.");
    }
}
