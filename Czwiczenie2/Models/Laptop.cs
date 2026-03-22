namespace Czwiczenie2.Models;

public class Laptop : Electronic
{
    public string Processor {get; set;}
    public int Memory { get; set; }

    public Laptop(string name, string serialNumber, string processor, int memory)
        :base(name, serialNumber)
    {
        Processor = processor;
        Memory = memory;
    }
    
}