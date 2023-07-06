using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create locations
        City capeTown = new City
        {
            Name = "Cape Town",
            Region = "Western Cape",
            Weather = "Moderate",
            Currency = "South African Rand"
        };

        Beach durbanBeach = new Beach
        {
            Name = "Durban Beach",
            Region = "KwaZulu-Natal",
            Weather = "Hot",
            WaterTemperature = "Warm"
        };

        // Display location information
        Console.WriteLine("Vacation Advisor");
        Console.WriteLine("----------------");
        Console.WriteLine();

        Console.WriteLine("City Information:");
        capeTown.DisplayInformation();
        Console.WriteLine();

        Console.WriteLine("Beach Information:");
        durbanBeach.DisplayInformation();
        Console.WriteLine();

        // Suggest outfit options based on weather
        Console.WriteLine("Outfit Suggestions:");
        Console.WriteLine($"Weather: {capeTown.Weather}");
        Console.WriteLine($"Outfit: {OutfitAdvisor.GetOutfit(capeTown.Weather)}");
        Console.WriteLine();

        // Suggest activities to do
        Console.WriteLine("Activities to Do:");
        Console.WriteLine($"Region: {capeTown.Region}");
        List<string> activities = ActivityAdvisor.GetActivities(capeTown.Region);
        foreach (string activity in activities)
        {
            Console.WriteLine(activity);
        }
        Console.WriteLine();

        // Suggest restaurants to try
       

        
    }
}
