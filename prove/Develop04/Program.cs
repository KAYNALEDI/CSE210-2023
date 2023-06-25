using System;
using System.Threading;
/*



*** The listing activity is not working correctly. It cannot enter
any items and then it says I have enter the same number of items 
as the number of seconds entered ***

*/



public class Activity
{
    protected string _name;
    protected string _description;
    

    public Activity(string _name, string _description)
    {
        this._name = _name;
        this._description = _description;
    }

    public virtual void Start(int duration)
    {
        Console.WriteLine($"Starting {_name} activity...");
        Console.WriteLine(_description);
        Thread.Sleep(2000);

        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
    }

    public virtual void End()
    {
        Console.WriteLine("Well done! Activity completed.");
        Thread.Sleep(2000);
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through deep breathing.")
    {
    }

    public override void Start(int duration)
    {
        base.Start(duration);

        int breathTime = duration / 2;
        int pauseTime = 2000;

        for (int i = 0; i < breathTime; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(pauseTime);

            Console.WriteLine("Breathe out...");
            Thread.Sleep(pauseTime);
        }

        base.End();
    }
}

public class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times when you have shown strength and resilience.")
    {
    }

    public override void Start(int duration)
    {
        base.Start(duration);

        int promptIndex = new Random().Next(prompts.Length);
        string prompt = prompts[promptIndex];

        Console.WriteLine(prompt);
        Thread.Sleep(2000);

        int x = duration;
        string all = ".";
        foreach (string question in questions)
        {
            if (duration > 0)
            {
                Console.WriteLine(question);
                Console.WriteLine(all);
                // Console.WriteLine("Duration left : " + duration);
                Thread.Sleep(1000);                
                duration--;
                all = all + ".";  
            }     
        }
        
        



        base.End();
    }
}

public class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life.")
    {
    }

    public override void Start(int duration)
    {
        base.Start(duration);

        int promptIndex = new Random().Next(prompts.Length);
        string prompt = prompts[promptIndex];

        Console.WriteLine(prompt);
        Thread.Sleep(2000);

        Console.WriteLine("Start listing...");
        Thread.Sleep(duration * 1000);

        Console.WriteLine($"You listed {duration} items.");
        Thread.Sleep(2000);

        base.End();
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness App!");

        while (true)
        {
            Console.WriteLine("/nPlease select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            Console.Write("Enter the duration (in seconds) : ");
            int duration;
            string _duration = Console.ReadLine();
            if (_duration != "")
            {
                duration = Int32.Parse(_duration);
            }
            else
            {
                Console.WriteLine("Can only enter integers. Try again!!");
                Thread.Sleep(2000);
                break;
            }

            Activity activity;
            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }
            Console.Clear();
            activity.Start(duration);
        }
    }
}
