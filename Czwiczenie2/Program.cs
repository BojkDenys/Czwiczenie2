using Czwiczenie2.Models;
using Czwiczenie2.Service;
using Czwiczenie2.Util;

ElectronicService electronicService = new ElectronicService();
RentService rentService = new RentService();
UserService userService = new UserService();
StatisticService statisticService = new StatisticService(electronicService, rentService);
Printer printer = new Printer(electronicService, rentService);
Laptop laptop1 = new Laptop("Asus G16", "qsd982doqa8eq", "Ryzen 9", 32);
Laptop laptop2 = new Laptop("MacBook Air", "dsae87a2hjq233h", "Apple M4", 16);
Projector projector1 = new Projector("SAMSUNG", "sg17e21g772eggs22", 230);
Projector projector2 = new Projector("PHILIPS NeoPix 450", "s54S52STFS67", 500);
Camera camera1 = new Camera("CANON", "sswq727sq76222", 50);
Camera camera2 = new Camera("Sony", "c8w7637udhwer3", 75);
electronicService.Add(laptop1);
electronicService.Add(laptop2);
electronicService.Add(projector1);
electronicService.Add(projector2);
electronicService.Add(camera1);
electronicService.Add(camera2);
printer.showAllElectronic();
Student student1 = new Student("Artur", "Tygranow", "s20333");
Student student2 = new Student("Roman", "Kalyma", "s30005");
Employee employee = new Employee("Yuriy", "Pelmen", "Professor",13000);
userService.Add(student1);
userService.Add(student2);
userService.Add(employee);
Console.WriteLine("Renting: ");
Console.WriteLine($"Renting {laptop1.Name} for student {student1.FirstName} {student1.LastName}");
rentService.Rent(student1, laptop1, 7);
Console.WriteLine($"Renting {projector1.Name} for student {student1.FirstName} {student1.LastName}");
rentService.Rent(student1, projector1, 3);
Console.WriteLine("Try to rent rented electronic");
try
{
    rentService.Rent(student2, laptop1, 10);
}
catch (InvalidOperationException e)
{
    Console.WriteLine(e.Message);
}
Console.WriteLine("Try to rent more than limit electronics for student");
try
{
    rentService.Rent(student1, camera1, 2);
}
catch (InvalidOperationException e)
{
    Console.WriteLine(e.Message);
}
electronicService.SendElectronicToService(camera1.Id);
Console.WriteLine("Try to rent camera that is in service");
try
{
    rentService.Rent(student2, camera1, 2);
}
catch (InvalidOperationException e)
{
    Console.WriteLine(e.Message);
}

