// Program.cs
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // List to store all goals
    private static List<Goal> _goals = new List<Goal>();
    
    // User's total score
    private static int _score = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest!");
        Console.WriteLine();

        bool running = true;
        while (running)
        {
            // Display current score
            Console.WriteLine($"\nYou have {_score} points.\n");

            // Show menu
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            // Create Simple Goal
            SimpleGoal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (type == "2")
        {
            // Create Eternal Goal
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (type == "3")
        {
            // Create Checklist Goal
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(goal);
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("\nThe goals are:");
        
        for (int i = 0; i < _goals.Count; i++)
        {
            // Using polymorphism - each goal type displays differently!
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    static void RecordEvent()
    {
        ListGoals();
        
        Console.Write("\nWhich goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex];

            // Check if goal is already complete
            if (selectedGoal.IsComplete())
            {
                Console.WriteLine("This goal is already complete!");
                return;
            }

            // Record the event
            selectedGoal.RecordEvent();

            // Add points
            int pointsEarned = selectedGoal.GetPoints();
            _score += pointsEarned;

            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");

            // Check if it's a ChecklistGoal and if it just got completed
            if (selectedGoal is ChecklistGoal checklistGoal)
            {
                if (checklistGoal.IsComplete() && checklistGoal.GetAmountCompleted() == checklistGoal.GetTarget())
                {
                    // Just completed! Give bonus
                    int bonus = checklistGoal.GetBonus();
                    _score += bonus;
                    Console.WriteLine($"BONUS! You completed the goal! You earned an additional {bonus} points!");
                }
            }

            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    static void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // First line: save the score
            outputFile.WriteLine(_score);

            // Following lines: save each goal
            foreach (Goal goal in _goals)
            {
                // Using polymorphism - each goal type saves differently!
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    static void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            // Clear current goals
            _goals.Clear();

            // First line is the score
            _score = int.Parse(lines[0]);

            // Rest of the lines are goals
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':');
                
                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');

                if (goalType == "SimpleGoal")
                {
                    string name = goalData[0];
                    string description = goalData[1];
                    int points = int.Parse(goalData[2]);
                    bool isComplete = bool.Parse(goalData[3]);

                    SimpleGoal goal = new SimpleGoal(name, description, points, isComplete);
                    _goals.Add(goal);
                }
                else if (goalType == "EternalGoal")
                {
                    string name = goalData[0];
                    string description = goalData[1];
                    int points = int.Parse(goalData[2]);

                    EternalGoal goal = new EternalGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (goalType == "ChecklistGoal")
                {
                    string name = goalData[0];
                    string description = goalData[1];
                    int points = int.Parse(goalData[2]);
                    int bonus = int.Parse(goalData[3]);
                    int target = int.Parse(goalData[4]);
                    int amountCompleted = int.Parse(goalData[5]);

                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                    _goals.Add(goal);
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}