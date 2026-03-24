namespace Czwiczenie2.Models;

public class Student : User
{
    public string StudentNumber { get; set; }

    public Student(string firstname, string lastname, string studentNumber)
        : base(firstname,lastname)
    {
        StudentNumber = studentNumber;
    }

    public override int MaxRentCount
    {
        get
        {
            return 2;
        }
    }

    public override string GetType
    {
        get
        {
            return "Student";
        }
    }
}