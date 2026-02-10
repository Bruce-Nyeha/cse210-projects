using System;

public class Square: Shape
{
    private double _side;

    public Square(string color, double Side): base(color)
    {
        _side = Side;
    }


    public override double GetArea()
    {

        return _side * _side;
    }
}