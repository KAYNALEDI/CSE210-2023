using System;
using System.Collections.Generic;

// Base class for all goals
public abstract class Goal
{
    private string name;
    private int points;
    private bool isCompleted;

    public string Name { get => name; set => name = value; }
    public int Points { get => points; set => points = value; }
    public bool IsCompleted { get => isCompleted; set => isCompleted = value; }

    protected Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public abstract void RecordEvent();
    public abstract string GetProgress();
}

// Simple goal class
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points)
    {
    }

    public override void RecordEvent()
    {
        IsCompleted = true;
    }

    public override string GetProgress()
    {
        return IsCompleted ? "[X]" : "[ ]";
    }
}

// Eternal goal class
public class EternalGoal : Goal
{
    private int timesCompleted;

    public EternalGoal(string name, int points) : base(name, points)
    {
        timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        timesCompleted++;
    }

    public override string GetProgress()
    {
        return "Completed " + timesCompleted + " times";
    }
}

// Checklist goal class
public class ChecklistGoal : Goal
{
    private int targetCount;
    private int timesCompleted;

    public ChecklistGoal(string name, int points, int targetCount) : base(name, points)
    {
        this.targetCount = targetCount;
        timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        timesCompleted++;
        if (timesCompleted >= targetCount)
        {
            IsCompleted = true;
        }
    }

    public override string GetProgress()
    {
        return "Completed " + timesCompleted + "/" + targetCount + " times";
    }
}

// Main program
public partial class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int totalScore = 0;

    public static void Main()
    {
        // Sample goals
        goals.Add(new SimpleGoal("Run a marathon", 1000));
        goals.Add(new EternalGoal("Read scriptures", 100));
        goals.Add(new ChecklistGoal("Attend the temple", 50, 10));

        int choice;
        do
        {
            Console.WriteLine("Eternal Quest");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. View Score");
            Console.WriteLine("4. Create New Goal");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    ViewGoals();
                    break;
                case 2:
                    RecordEvent();
                    break;
                case 3:
                    ViewScore();
                    break;
                case 4:
                    CreateGoal();
                    break;
                case 5:
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        } while (choice != 5);
    }

    private static void ViewGoals()
    {
        Console.WriteLine("Goals:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.Name + " " + goal.GetProgress());
        }
    }

    private static void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + goals[i].Name);
        }
        int goalIndex = Convert.ToInt32(Console.ReadLine()) - 1;
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].RecordEvent();
            totalScore += goals[goalIndex].Points;
            Console.WriteLine("Event recorded successfully!");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    private static void ViewScore()
    {
        Console.WriteLine("Total Score: " + totalScore);
    }

    private static void CreateGoal()
    {
        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter the type of the goal (1 - Simple, 2 - Eternal, 3 - Checklist): ");
        int type = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the points for the goal: ");
        int points = Convert.ToInt32(Console.ReadLine());

        Goal goal;
        switch (type)
        {
            case 1:
                goal = new SimpleGoal(name, points);
                break;
            case 2:
                goal = new EternalGoal(name, points);
                break;
            case 3:
                Console.Write("Enter the target count for the checklist goal: ");
                int targetCount = Convert.ToInt32(Console.ReadLine());
                goal = new ChecklistGoal(name, points, targetCount);
                break;
            default:
                Console.WriteLine("Invalid goal type. Creating a simple goal by default.");
                goal = new SimpleGoal(name, points);
                break;
        }

        goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    private static void CheckBonusRewards(List<BonusReward> bonusRewards)
    {
        foreach (BonusReward reward in bonusRewards)
        {
            if (reward.IsAchieved(totalScore))
            {
                Console.WriteLine("Bonus Reward: {0} points - {1}", reward.BonusPoints, reward.Message);
                totalScore += reward.BonusPoints;
            }
        }
    }
}
