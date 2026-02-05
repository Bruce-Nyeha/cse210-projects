using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?"
    };

    public ReflectionActivity() 
        : base("Reflection Activity", 
               "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine(prompt);
        ShowSpinner(5);  // Pause to think

        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        ShowCountdown(5);

        int timeLeft = _duration - 10;  // subtract initial pause
        int questionIndex = 0;

        while (timeLeft > 0)
        {
            string question = _questions[questionIndex % _questions.Count];
            Console.WriteLine("> " + question);
            ShowSpinner(10);  // 10 seconds per question
            timeLeft -= 10;
            questionIndex++;
        }

        DisplayEndingMessage();
    }
}