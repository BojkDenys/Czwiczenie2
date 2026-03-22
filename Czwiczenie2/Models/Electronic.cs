using Czwiczenie2.Enums;

namespace Czwiczenie2.Models;

public abstract class Electronic
{
    private static int _idGenerator = 1;
    public int Id { get; }
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public RentStatus RentStatus { get; set; }
    protected  Electronic(string name, string serialNumber)
    {
        Id = _idGenerator++;
        Name = name;
        SerialNumber = serialNumber;
        RentStatus = RentStatus.Free;
    }
    

    public override string ToString()
    {
        return $"Id: {Id}\nName: {Name}\nSerial number: {SerialNumber}\nRent status: {RentStatus}";
    }
    
}