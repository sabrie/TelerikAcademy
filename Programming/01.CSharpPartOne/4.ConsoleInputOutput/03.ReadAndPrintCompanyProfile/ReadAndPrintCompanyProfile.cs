/* A company has name, address, phone number, fax number, web site and manager. 
 * The manager has first name, last name, age and a phone number. 
 * Write a program that reads the information about a company and 
 * its manager and prints them on the console.
 */
using System;

class ReadAndPrintCompanyProfile
{
    static void Main()
    {
        Console.Write("Enter company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Enter company address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Enter company phone number: ");
        string companyPhone = Console.ReadLine();
        Console.Write("Enter company fax number: ");
        string companyFax = Console.ReadLine();
        Console.Write("Enter company web site: ");
        string companyWebSite = Console.ReadLine();
        Console.Write("Enter manager first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Enter manager last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Enter manager age: ");
        ushort managerAge = ushort.Parse(Console.ReadLine());
        Console.Write("Enter manager pnone: ");
        string managerPhone = Console.ReadLine();

        Console.WriteLine();

        Console.WriteLine("Company name: {0}", companyName);
        Console.WriteLine("Company address: {0}", companyAddress);
        Console.WriteLine("Company phone number: {0}", companyPhone);
        Console.WriteLine("Company fax number: {0}", companyFax);
        Console.WriteLine("Company web site: {0}", companyWebSite);
        Console.WriteLine("Manager's first name: {0}", managerFirstName);
        Console.WriteLine("Manager's last name: {0}", managerLastName);
        Console.WriteLine("Manager's age: {0}", managerAge);
        Console.WriteLine("Manager's phone: {0}", managerPhone);
    }
}

