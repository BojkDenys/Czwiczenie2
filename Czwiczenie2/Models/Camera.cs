namespace Czwiczenie2.Models;

public class Camera : Electronic
{
    public int Pixels { get; set; }

    public Camera(string name, string serialNumber, int pixels)
        : base(name,serialNumber)
    {
        Pixels = pixels;
    }
}