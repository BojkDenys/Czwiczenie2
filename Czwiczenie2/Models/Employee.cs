namespace Czwiczenie2.Models;

public class Employee : User
{
    public string Position { get; set; }
    public int Salary { get; set; }

    public Employee(string fistname, string lastname, string position, int salary)
        : base(fistname, lastname)
    {
        Position = position;
        Salary = salary;
    }

    public override int MaxRentCount
    {
        get
        {
            return 5;
        }
    }

    public override string GetType
    {
        get
        {
            return "Employee";
        }
    }
}