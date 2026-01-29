using System;


public class Product
{
    private string _name;
    private int _productID;
    private double _price;
    private int _quantity;


    // the constructor with parameters
    public Product(string name, int productID, double price, int quantity)
    {
        _name = name;
        _productID = productID;
        _price = price;
        _quantity = quantity;
    }

    // Computes total cost = price per unit × quantity
    public double TotalProductCost()
    {
       return _price * _quantity;
    }
    
    //getters
    public string GetName(){
        return _name;
    }


    public int GetProductID()
    {
        return _productID;
    }

    public double GetPrice()
    {
        return _price;
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    //Setters to change some details later
    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name cannot be empty");
            return;
        }
        _name = name;
    }

    public void SetPrice(double price)
    {
        if (price < 0)
        {
            Console.WriteLine("Price cannot be negative");
            return;
        }
        _price = price;
    }

    public void SetQuantity(int quantity)
    {
        if (quantity < 0)
        {
            Console.WriteLine("Quantity cannot be negative");
            return;
        }
        _quantity = quantity;
    }

    public void DisplayProductDetails()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Product ID: {_productID}");
        Console.WriteLine($"Price: ${_price:C}");
        Console.WriteLine($"Quantity: {_quantity}");
        Console.WriteLine($"Total Cost: {TotalProductCost():C}");
        Console.WriteLine("------------");
    }
}