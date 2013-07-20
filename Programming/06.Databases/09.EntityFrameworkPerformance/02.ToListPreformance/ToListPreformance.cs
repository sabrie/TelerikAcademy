/*
 * Task 02.
 Using Entity Framework write a query that selects all employees from 
 the Telerik Academy database, then invokes ToList(), then selects 
 their addresses, then invokes ToList(), then selects their towns, 
 then invokes ToList() and finally checks whether the town is "Sofia".
 Rewrite the same in more optimized way and compare the performance.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.Data;


class ToListPreformance
{
    static void Main()
    {
        TelerikAcademyEntities context = new TelerikAcademyEntities();
        
        // Low performance
        // SQL statements are executed each time we invoke ToList();
        var allEmployeesUsingToList = context.Employees.ToList()
            .Select(e => e.Address).ToList()
            .Select(e => e.Town).ToList()
            .Where(t => t.Name == "Sofia");

        // Better performance
        // SQL statement is executed only when we call 'foreach'
        var allEmployeesWithoutToList = context.Employees
           .Select(e => e.Address)
           .Select(e => e.Town)
           .Where(t => t.Name == "Sofia");

        using (context)
        {
            // 646 SQL statements are executed 
            foreach (var employee in allEmployeesUsingToList)
            {
                Console.WriteLine(employee.Name);
            }

            // 1 SQL statement is executed
            foreach (var employee in allEmployeesWithoutToList)
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}

