namespace Czwiczenie2.Models;

public class Student : User
{
    public string StudentNumber { get; set; }

    public Student(string firstname, string lastname, string studentNumber)
        : base(firstname,lastname)
    {
        StudentNumber = studentNumber;
    }
}