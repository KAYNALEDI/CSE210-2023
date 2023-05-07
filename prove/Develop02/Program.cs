using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry()
    {
        Console.Write("What brings you joy? ");
        string prompt = Console.ReadLine();

        Console.Write("Describe a place where you felt happiest. ");
        string response = Console.ReadLine();

        Console.Write("What was your greatest fear, and how did you conquer it? ");
        string response2 = Console.ReadLine();

        Console.Write("List down a bucket list with the things that you have always wanted to do. ");
        string response3 = Console.ReadLine();

        Console.Write("Where do you see yourself in the next 1, 3, 5, 10 years from now? ");
        string response4 = Console.ReadLine();

        Entry newEntry = new Entry(prompt, response, response2, response3, response4);
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
                Entry newEntry = new Entry(parts[0], parts[1], parts[2], parts[3], parts[4]);
                entries.Add(newEntry);
            }
        }
    }
}

class Entry
{
    private string prompt;
    private string response;
    private string response2;
    private string response3;
    private string response4;

    public Entry(string prompt, string response, string response2, string response3, string response4)
    {
        this.prompt = prompt;
        this.response = response;
        this.response2 = response2;
        this.response3 = response3;
        this.response4 = response4;
    }

    public override string ToString()
    {
        return $"{prompt}\n{response}\n{response2}\n{response3}\n{response4}\n";
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
