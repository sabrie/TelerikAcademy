/*
 Task 01.
 Using Entity Framework write a SQL query to select all employees from 
 the Telerik Academy database and later print their name, department and 
 town. Try the both variants: with and without .Include(…). Compare the 
 number of executed SQL statements and the performance.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.Data;

class SelectEmployeesUsingInclude
{
    static void Main()
    {
        TelerikAcademyEntities context = new TelerikAcademyEntities();

        using (context)
        {
            // Low performance if not using .Include(...);
            // 339 SQL statements are executed
            foreach (var employee in context.Employees)
            {
                Console.WriteLine("Employee name: {0} {1}; ", employee.FirstName, employee.LastName);
                Console.Write("Department: {0}; ", employee.Department.Name);
                Console.Write("Town: {0}", employee.Address.Town.Name);
                Console.WriteLine();
                Console.WriteLine();
            }

            // Better performance when using .Include();
            // Only 1 SQL statement is executed 
            foreach (var employee in context.Employees.Include("Department").Include("Address.Town"))
            {
                Console.WriteLine("Employee name: {0} {1}; ", employee.FirstName, employee.LastName);
                Console.Write("Department: {0}; ", employee.Department.Name);
                Console.Write("Town: {0}", employee.Address.Town.Name);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}

