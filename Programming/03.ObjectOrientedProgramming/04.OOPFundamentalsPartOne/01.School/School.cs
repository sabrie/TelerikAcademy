using System;
using System.Collections.Generic;
using System.Text;

class School
{
    // field
    private List<Class> classes;

    // property
    public List<Class> Classes { get; set; }

    // constructor
    public School(List<Class> classes)
    {
        this.Classes = classes;
    }

    // override ToString(); in order to print the information about the School in the following format
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        foreach (var item in this.Classes)
        {
            result.Append(item.ToString());            
        }
        Console.WriteLine();
        return result.ToString();
    }
}
