using System;
using System.Collections.Generic;

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        Entry entry = new Entry(prompt, response);
        entries.Add(entry);
    }

    public void Display()
    {
        Console.WriteLine("Journal Entries:");
        Console.WriteLine("------------------");
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"{entry.Prompt}: {entry.Response}");
        }
    }

    public void Save(string filename)
    {
        // implementation for saving the journal to a file
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void Load(string filename)
    {
        // implementation for loading the journal from a file
        Console.WriteLine($"Journal loaded from {filename}");
    }
}

class Entry
{
    private string prompt;
    private string response;

    public Entry(string prompt, string response)
    {
        this.prompt = prompt;
        this.response = response;
    }

    public string Prompt
    {
        get { return prompt; }
    }

    public string Response
    {
        get { return response; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        Console.WriteLine("Enter filename to load journal from:");
        string filename = Console.ReadLine();
        journal.Load(filename);
        journal.Display();
        Console.WriteLine("Enter new journal entry prompt:");
        string prompt = Console.ReadLine();
        Console.WriteLine("Enter new journal entry response:");
        string response = Console.ReadLine();
        journal.AddEntry(prompt, response);
        Console.WriteLine("Enter filename to save journal to:");
        filename = Console.ReadLine();
        journal.Save(filename);
    }
}
