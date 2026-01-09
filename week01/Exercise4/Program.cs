using System;
using System.Collections.Generic;  

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        int input;
        do
        {
            Console.Write("Enter number: ");
            string valueString = Console.ReadLine();
            input = int.Parse(valueString);

            if (input != 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);

        // 1. Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // 2. Compute the average
        float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // 3. Find the maximum
        int maximum = numbers[0];  
        foreach (int number in numbers)
        {
            if (number > maximum)
            {
                maximum = number;
            }
        }
        Console.WriteLine($"The largest number is: {maximum}");
    }
}