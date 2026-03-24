using System.Formats.Tar;
using Czwiczenie2.Enums;
using Czwiczenie2.Models;

namespace Czwiczenie2.Service;

public class RentService
{
    private readonly List<Rent> _rents = new();

    public void Rent(User user, Electronic electronic, int days)
    {
        if (electronic.RentStatus != RentStatus.Free)
        {
            throw new InvalidOperationException($"Electronic with id {electronic.Id} is unavailable");
        }

        List<Rent> rents = GetActiveRentsForUser(user);
        if (rents.Count >= user.MaxRentCount)
        {
            throw new InvalidOperationException($"User with id {user.Id} already has max count of rents");
        }

        Rent rent = new Rent(user, electronic, days);
        electronic.RentStatus = RentStatus.Rented;
        _rents.Add(rent);
        
    }

    public void Return(int rentId,DateTime? returnTime = null)
    {
        Rent rent = _rents.FirstOrDefault(r => r.Id == rentId) ?? throw new InvalidOperationException($"Rent with id {rentId} with not found");
        if (rent.ReturnTime.HasValue)
        {
            throw new InvalidOperationException($"Rent with id {rentId} already returned");
        }

        rent.ReturnTime = returnTime ?? DateTime.Now;
        rent.Electronic.RentStatus = RentStatus.Free;
        if (rent.ReturnTime > rent.DueTime)
        {
            rent.Fine = (int)Math.Ceiling((rent.ReturnTime.Value - rent.DueTime).TotalDays) * 5;
        }

        
    }

    public List<Rent> GetActiveRentsForUser(User user)
    {
        return _rents.Where(r => r.User.Id == user.Id && !r.ReturnTime.HasValue).ToList();
    }

    public List<Rent> GetAllOvertimed()
    {
        return _rents.Where(r =>!r.ReturnTime.HasValue && DateTime.Now > r.DueTime).ToList();
    }

    public List<Rent> GetAll()
    {
        return new(_rents);
    }
}