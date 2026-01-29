using System;

public class Customer
{
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Getter for name (needed for shipping label in Order)
    public string GetName()
    {
        return _name;
    }

    // Getter for address object (needed so Order can call GetFullAddress() on it)
    public Address GetAddress()
    {
        return _address;
    }

    // Method to check if in USA (delegates to Address — already there)
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    // Optional: Display method for testing
    public void DisplayCustomerInfo()
    {
        Console.WriteLine($"Customer: {_name}");
        Console.WriteLine("Address:");
        Console.WriteLine(_address.GetFullAddress());
        Console.WriteLine($"In USA? {IsInUSA()}");
        Console.WriteLine("-------------------");
    }
}