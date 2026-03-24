using Czwiczenie2.Models;
using Czwiczenie2.Service;

namespace Czwiczenie2.Util;

public class Printer
{
    private readonly ElectronicService _electronicService;
    private readonly RentService _rentService;

    public Printer(ElectronicService electronicService, RentService rentService)
    {
        _electronicService = electronicService;
        _rentService = rentService;
    }

    public void showAllElectronic()
    {
        Console.WriteLine("All electronic: ");
        List<Electronic> electronics = _electronicService.GetAll();
        if (electronics.Count == 0)
        {
            Console.WriteLine("Empty");
        }

        foreach (Electronic electronic in electronics)
        {
            Console.WriteLine(electronic);
        }
    }

    public void PrintFreeElectronic()
    {
        Console.WriteLine("Free electronic:");
        List<Electronic> electronics = _electronicService.GetAllFree();
        if (electronics.Count == 0)
        {
            Console.WriteLine("Empty");
        }

        foreach (Electronic electronic in electronics)
        {
            Console.WriteLine(electronic);
        }
    }
}