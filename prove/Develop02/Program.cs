using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry()
    {
        Console.Write("Enter today's date (MM/DD/YYYY): ");
        string date = Console.ReadLine();

        Console.WriteLine(GetRandomPrompt());

        Console.Write("Write your response: ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry(date, response);
        entries.Add(newEntry);
    }

    public void Display()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void Save(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                sw.WriteLine(entry.ToString());
            }
        }
    }

    public void Load(string filename)
    {
        using (StreamReader sr = new StreamReader(filename))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                Entry newEntry = new Entry(parts[0], parts[1]);
                entries.Add(newEntry);
            }
        }
    }

    private string GetRandomPrompt()
    {
        string[] prompts = {
            "What brings you joy?",
            "Describe a place where you felt happiest.",
            "What was your greatest fear, and how did you conquer it?",
            "List down a bucket list with the things that you have always wanted to do.",
            "Where do you see yourself in the next 1, 3, 5, 10 years from now?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }
}

class Entry
{
    private string date;
    private string response;

    public Entry(string date, string response)
    {
        this.date = date;
        this.response = response;
    }

    public override string ToString()
    {
        return $"{date}\n{response}\n";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();

        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            myJournal.Load(filename);
        }

        while (true)
        {
            Console.WriteLine("Enter 'add' to add a new entry, 'display' to display all entries, 'save' to save entries to file, or 'exit' to exit.");
            string command = Console.ReadLine();

            switch (command)
            {
                case "add":
                    myJournal.AddEntry();
                    break;
                case "display":
                    myJournal.Display();
                    break;
                case "save":
                    Console.Write("Enter filename to save to: ");
                    string saveFilename = Console.ReadLine();
                    myJournal.Save(saveFilename);
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
        }
    }
}
