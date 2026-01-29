using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products = new List<Product>();  
    private Customer _customer;  

    // Constructor: takes customer and adds products later
    public Order(Customer customer)
    {
        _customer = customer;
    }

    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    
    public double CalculateTotalCost()
    {
        double productTotal = 0;

        foreach (Product p in _products)
        {
            productTotal += p.TotalProductCost();  
        }

        double shippingCost = _customer.IsInUSA() ? 5.0 : 35.0;

        return productTotal + shippingCost;
    }

    
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";

        foreach (Product p in _products)
        {
            label += $"Product: {p.GetName()} (ID: {p.GetProductID()})\n";
        }

        return label.TrimEnd();  // Remove extra newline
    }

    
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n" +
               $"Name: {_customer.GetName()}\n" +
               _customer.GetAddress().GetFullAddress();  // Calls Address method
    }

    
    public void DisplayOrder()
    {
        Console.WriteLine("=== Order Details ===");
        Console.WriteLine(GetShippingLabel());
        Console.WriteLine(GetPackingLabel());
        Console.WriteLine($"Total Cost: ${CalculateTotalCost():F2}");
        Console.WriteLine("====================");
    }
}