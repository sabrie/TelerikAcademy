using System;
using System.Text;

class Discipline
{
    // fields
    private string name;
    private int numberOfLectures;
    private int numberOfExercises;

    // properties
    public string Name { get; set; }
    public int NumberOfLectures { get; set; }
    public int NumberOfExercises { get; set; }

    // constructor
    public Discipline(string name, int numberOfLectures, int numberOfExercises)
    {
        this.Name = name;
        this.NumberOfLectures = numberOfLectures;
        this.NumberOfExercises = numberOfExercises;
    }

    // override ToString(); in order to print the information about the Disciplines in the following format
    public override string ToString()
    {
        return String.Format("{3} {0} {3}Number of Lectures: {1} {3}Number of Exercises: {2}",
            this.Name, this.NumberOfLectures, this.NumberOfExercises, Environment.NewLine);
    }
}