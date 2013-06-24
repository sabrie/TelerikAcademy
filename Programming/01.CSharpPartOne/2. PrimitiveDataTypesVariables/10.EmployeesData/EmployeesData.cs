/* A marketing firm wants to keep record of its employees. Each record would 
 * have the following characteristics – first name, family name, age, gender (m or f), 
 * ID number, unique employee number (27560000 to 27569999). Declare the variables 
 * needed to keep the information for a single employee using appropriate data types 
 * and descriptive names.
 */
using System;

class EmployeesData
{
    static void Main()
    {
        string firstName = "Sabrie";
        string familyName = "Nedzhip";
        byte age = 29;
        char gender = 'f';
        ulong id = 1234567891u;
        uint uniqueNumber = 27562534;
    }
}

