using System;

class Beach : Location
{
    public string WaterTemperature { get; set; }

    public override void DisplayInformation()
    {
        base.DisplayInformation();
        Console.WriteLine($"Water Temperature: {WaterTemperature}");
    }
}
