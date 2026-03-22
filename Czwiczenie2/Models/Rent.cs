namespace Czwiczenie2.Models;

public class Rent
{
    public static int _IdGenerate = 1;
    public int Id { get; }
    public User User { get; }
    public Electronic Electronic { get; }
    public DateTime RentTime { get; }
    public DateTime DueTime { get; }
    public DateTime? ReturnTime { get; set; }
    public decimal Fine { get; set; }

    public Rent(User user, Electronic electronic, int days)
    {
        Id = _IdGenerate++;
        User = user;
        Electronic = electronic;
        RentTime = DateTime.Now;
        DueTime = RentTime.AddDays(days);
        
    }

    public void Return(DateTime returnTime)
    {
        ReturnTime = returnTime;
        if (ReturnTime > DueTime)
        {
            int days = (int)((returnTime - DueTime).TotalDays) + 1;
            Fine = days * 10;
        }
    }

    public override string ToString()
    {
        if (ReturnTime.HasValue)
        {
            if (ReturnTime > DueTime)
            {
                return
                    $"Rent #{Id}( {Electronic.Name} by {User.FirstName} {User.LastName}) rented {RentTime} returned{ReturnTime}, fine {Fine} zl";
            }
            else
            {
               return $"Rent #{Id}( {Electronic.Name} by {User.FirstName} {User.LastName}) rented {RentTime} returned{ReturnTime},no fine";
            }
        }
        else
        {
            return $"Rent #{Id}( {Electronic.Name} by {User.FirstName} {User.LastName}) rented {RentTime} not returned,due time {DueTime}";
        }
    }
}