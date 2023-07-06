using System;

class OutfitAdvisor
{
    public static string GetOutfit(string weather)
    {
        if (weather.ToLower() == "hot")
            return "Light and breathable clothing, sunglasses, and a hat.";
        else if (weather.ToLower() == "moderate")
            return "Comfortable clothing, a light jacket, and sunscreen.";
        else if (weather.ToLower() == "cold")
            return "Warm clothing, a coat, gloves, and a scarf.";
        else
            return "Weather information not available.";
    }
}
