using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fractions = new Fraction();
        
        Console.WriteLine(fractions.GetFractionString());
        Console.WriteLine(fractions.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());  
        Console.WriteLine(f2.GetDecimalValue());
    }
}