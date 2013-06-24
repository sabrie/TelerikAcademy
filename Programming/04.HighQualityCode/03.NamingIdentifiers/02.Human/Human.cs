using System;
using System.Linq;
using System.Text;

class Human
{
    public Gender Gender { get; set; }
    public string Name { get; set; }

    public void GetGenderById(long id)
    {
        if (id % 2 == 0)
        {
            this.Name = "Man";
            this.Gender = Gender.Male;
        }
        else
        {
            this.Name = "Woman";
            this.Gender = Gender.Female;
        }
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();

        output.AppendLine("Name: " + this.Name);
        output.AppendLine("Sex: " + this.Gender);

        return output.ToString();
    }
}
