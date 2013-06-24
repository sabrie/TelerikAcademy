using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Student Information");
        Console.WriteLine();
        Student student = new Student("Svetlin", "Nakov", "Nakov", "123456", "Telerik Street 1", "0888 564321", 
                                "nakov@gmail.com", "OOP", University.Telerik, Faculty.Programming, Specialty.SoftwareEngineer);

        Console.WriteLine(student);
        Console.WriteLine(new string('-', 40));
        Console.WriteLine();

        // we copy the student using the implementation of method Clone() from ICloneable interface
        Console.WriteLine("COPY of the above student (using Clone();) - \nthe information should be the same as above");
        Student studentCopy = student.Clone();

        // print the copy of the student - the information should be the same 
        Console.WriteLine();
        Console.WriteLine(studentCopy);

        Console.WriteLine("Both students are equal: {0}", student.CompareTo(studentCopy) == 0 ? true : false); 

        Console.WriteLine(new string('-', 40));
        Console.WriteLine();

        Console.WriteLine("We change the first name and SSN of the COPY and print again both students");
        Console.WriteLine("Note that the name and SSN of the original student are not changed");
        Console.WriteLine("We change only the copy");
        Console.WriteLine();

        studentCopy.FirstName = "Ivan";
        studentCopy.SSN = "234567";

        Console.WriteLine("Original student");
        Console.WriteLine();
        Console.WriteLine(student);

        Console.WriteLine("Copy of the student");
        Console.WriteLine();
        Console.WriteLine(studentCopy);

        Console.WriteLine("Both students are equal: {0}", student.CompareTo(studentCopy) == 0 ? true : false);
        
        // another way to compare student using the overriden operator ==
        // Console.WriteLine("Both students are equal: {0}", student == studentCopy); // False
    }
}
