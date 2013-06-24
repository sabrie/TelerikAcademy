using System;
using System.Collections.Generic;
using System.Text;

class Person
{
    // properties
    public string Name { get; set; }
    public int? Age { get; set; }

    // constructor - age is not mandatory
    public Person(string name, int? age = null)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendFormat("Name: {0}", this.Name).AppendLine();
        
        // if age is not specified - we print -> Age: not specified
        if (this.Age == null)
        {
            result.AppendFormat("Age: not specified").AppendLine();
            return result.ToString();
        }

        result.AppendFormat("Age: {0}", this.Age).AppendLine();

        return result.ToString();
    }
}

