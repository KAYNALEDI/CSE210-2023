using System;

class City : Location
{
    public string Currency { get; set; }

    public override void DisplayInformation()
    {
        base.DisplayInformation();
        Console.WriteLine($"Currency: {Currency}");
    }
}
