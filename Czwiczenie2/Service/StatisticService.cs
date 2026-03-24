using Czwiczenie2.Enums;
using Czwiczenie2.Models;

namespace Czwiczenie2.Service;

public class StatisticService
{
    private readonly ElectronicService _electronicService;
    private readonly RentService _rentService;

    public StatisticService(ElectronicService electronicService, RentService rentService)
    {
        electronicService = _electronicService;
        rentService = _rentService;
    }

    public void ShowStatistic()
    {
        List<Electronic> allElectronic = _electronicService.GetAll();
        List<Rent> allRent = _rentService.GetAll();
        List<Rent> allOverTimed = _rentService.GetAllOvertimed();
        decimal totalFine = allRent.Sum(r => r.Fine);
        int countFree = allElectronic.Count(e => e.RentStatus == RentStatus.Free);
        int countService = allElectronic.Count(e => e.RentStatus == RentStatus.Service);
        int countRented = allElectronic.Count(e => e.RentStatus == RentStatus.Rented);
        Console.WriteLine("Statistic: ");
        Console.WriteLine($"Total count of electronic: {allElectronic.Count}");
        Console.WriteLine($"Count of free electronic: {countFree}");
        Console.WriteLine($"Count of Service electronic: {countService}");
        Console.WriteLine($"Count of Rented electronic: {countRented}");
        Console.WriteLine($"Total rents: {allRent.Count}");
        Console.WriteLine($"Count of overtimed: {allOverTimed.Count}");
        Console.WriteLine($"Total sum of fines: {totalFine}");
    }
}