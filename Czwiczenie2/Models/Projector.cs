namespace Czwiczenie2.Models;

public class Projector : Electronic 
{
    public int Lumens { get; set; }

    public Projector(string name, string serialNumber, int lumens)
        :base(name, serialNumber)
    {
        Lumens = lumens;
    }
}