using System;

class Worker : Human
{
    // properties
    public decimal WeekSalary { get; set; }
    public int WorkHoursPerDay { get; set; }

    // constructor
    public Worker(string firstName, string lastName, decimal weekSalary = 0, int workHoursPerDay = 0)
        : base(firstName, lastName) // we call the base constructor to initialize the first and last names
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    // method that calculates the money per hour
    public decimal MoneyPerHour()
    {
        return this.WeekSalary / (this.WorkHoursPerDay * 5);
    }

    // override ToString(); in order to print the information about the Worker in the following format
    public override string ToString()
    {
        return String.Format("{0} {1} {5}Week Salary: {2} {5}Work Hours per Day: {3} {5}Money Per Hour: {4} ",
            this.FirstName.ToUpper(), this.LastName.ToUpper(), this.WeekSalary, this.WorkHoursPerDay, this.MoneyPerHour(), Environment.NewLine);
    }
}
