using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mindfulness Activities");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.Write("Select an activity (1-3): ");

        string choice = Console.ReadLine();

        Activity activity = null;

        if (choice == "1")
            activity = new BreathingActivity();
        else if (choice == "2")
            activity = new ReflectionActivity();
        else if (choice == "3")
            activity = new ListingActivity();
        else
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        // Run the activity
        if (activity is BreathingActivity breathing)
            breathing.Run();
        else if (activity is ReflectionActivity reflection)
            reflection.Run();
        else if (activity is ListingActivity listing)
            listing.Run();
    }
}