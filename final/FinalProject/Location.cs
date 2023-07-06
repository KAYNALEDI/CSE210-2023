using System;

abstract class Location
{
    public string Name { get; set; }
    public string Region { get; set; }
    public string Weather { get; set; }

    public virtual void DisplayInformation()
    {
        Console.WriteLine($"Location: {Name}");
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Weather: {Weather}");
    }
}
