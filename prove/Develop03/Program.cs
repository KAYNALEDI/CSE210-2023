using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        Scripture john3_16 = new Scripture(new ScriptureReference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        john3_16.HideWords();

        while (!john3_16.IsFullyHidden()) {
            Console.ReadLine();
            Console.Clear();
            john3_16.HideWords();
        }
    }
}

class Scripture {
    private ScriptureReference reference;
    private string text;
    private List<Word> words;

    public Scripture(ScriptureReference reference, string text) {
        this.reference = reference;
        this.text = text;
        words = new List<Word>();
        string[] splitText = text.Split(' ');
        foreach (string s in splitText) {
            words.Add(new Word(s));
        }
    }

    public void HideWords() {
        Random random = new Random();
        foreach (Word w in words) {
            if (!w.IsHidden()) {
                if (random.Next(2) == 0) { // randomly hide half of the words
                    w.Hide();
                }
            }
        }
        Console.WriteLine(reference.ToString());
        Console.WriteLine();
        foreach (Word w in words) {
            Console.Write(w.ToString() + " ");
        }
    }

    public bool IsFullyHidden() {
        foreach (Word w in words) {
            if (!w.IsHidden()) {
                return false;
            }
        }
        return true;
    }
}

class ScriptureReference {
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public ScriptureReference(string book, int chapter, int verse) {
        this.book = book;
        this.chapter = chapter;
        startVerse = verse;
        endVerse = verse;
    }

    public ScriptureReference(string book, int chapter, int startVerse, int endVerse) {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public override string ToString() {
        if (startVerse == endVerse) {
            return book + " " + chapter + ":" + startVerse;
        } else {
            return book + " " + chapter + ":" + startVerse + "-" + endVerse;
        }
    }
}

class Word {
    private string word;
    private bool hidden;

    public Word(string word) {
        this.word = word;
        hidden = false;
    }

    public void Hide() {
        hidden = true;
    }

    public bool IsHidden() {
        return hidden;
    }

    public override string ToString() {
        if (hidden) {
            return "____";
        } else {
            return word;
        }
    }
}
