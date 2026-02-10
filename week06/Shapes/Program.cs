using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 5.0));
        shapes.Add(new Rectangle("Blue", 4.0, 6.0));
        shapes.Add(new Circle("Green", 3.0));  

        foreach (Shape s in shapes)
        {
            Console.WriteLine($"Color: {s.GetColor()}, Area: {s.GetArea():F2}");
        }
    }
}