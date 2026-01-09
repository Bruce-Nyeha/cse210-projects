using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");


        Console.Write("Enter grade percentage: ");
        string gradePercent = Console.ReadLine();
        int grade = int.Parse(gradePercent);
        
        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }

        else if (grade >= 80)
        {
            letter = "B";
        }

        else if (grade >= 70)
        {
            letter = "C";
        }

        else if (grade >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations!! You passed for this course.");
        }

        else
        {
            Console.WriteLine("More room for improvement. Keep it up");
        }
    }
}