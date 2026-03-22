namespace Czwiczenie2.Models;

public abstract class User
{
    private static int _IdGenerator = 1;
    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    protected User(string firstName, string lastName)
    {
        Id = _IdGenerator++;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"Id: {Id}\nFirstname {FirstName}\nLastname {LastName}";
    }
}