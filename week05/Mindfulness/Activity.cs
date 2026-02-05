using System;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;  

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    
    public void DisplayStartingMessage()
    {
        Console.WriteLine("Starting " + _name + "...");
        Console.WriteLine(_description);
        Console.Write("How long, in seconds, would you like for your session? ");

        
        string input = Console.ReadLine();
        if (int.TryParse(input, out int duration) && duration > 0)
        {
            _duration = duration;
        }
        else
        {
            Console.WriteLine("Invalid input. Using 30 seconds.");
            _duration = 30;
        }

        Console.WriteLine("Get ready...");
        ShowSpinner(3);  
    }

    // End message
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);  
    }

    
    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\", "" };
        int totalFrames = seconds * 10;  

        for (int i = 0; i < totalFrames; i++)
        {
            Console.Write(spinner[i % 4]);
            Thread.Sleep(500);  
            Console.Write("\b \b");  // Erase previous character
        }
        Console.WriteLine();
    }

    
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}