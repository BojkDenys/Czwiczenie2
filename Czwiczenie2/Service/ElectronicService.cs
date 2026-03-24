using Czwiczenie2.Enums;
using Czwiczenie2.Models;

namespace Czwiczenie2.Service;

public class ElectronicService
{
    private readonly List<Electronic> _electronics = new();

    public void Add(Electronic electronic)
    {
        _electronics.Add(electronic);
    }

    public Electronic? GetById(int id)
    {
        return _electronics.FirstOrDefault(e => e.Id == id);
    }

    public List<Electronic> GetAll()
    {
        return new(_electronics);
    }

    public List<Electronic> GetAllFree()
    {
        return _electronics.Where(e => e.RentStatus == RentStatus.Free).ToList();
    }

    public void SendElectronicToService(int id)
    {
        Electronic electronic = GetById(id) ?? throw new InvalidOperationException($"Electronic with id {id} not found");
        if (electronic.RentStatus == RentStatus.Rented)
        {
            throw new InvalidOperationException($"Electronic with id {id} in rent, so it sent to service");
        }

        electronic.RentStatus = RentStatus.Service;
    }
}