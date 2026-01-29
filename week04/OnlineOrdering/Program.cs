using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - USA customer
        Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer cust1 = new Customer("Jane Doe", addr1);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Solar Panel", 101, 150.00, 2));
        order1.AddProduct(new Product("Inverter", 102, 300.00, 1));

        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("\n" + order1.GetPackingLabel());
        Console.WriteLine($"\nTotal Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine("-------------------");

        // Order 2 - International customer
        Address addr2 = new Address("456 High St", "Accra", "Greater Accra", "Ghana");
        Customer cust2 = new Customer("Bruce Nyeha", addr2);

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Battery Pack", 103, 200.00, 3));
        order2.AddProduct(new Product("Charge Controller", 104, 80.00, 5));

        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("\n" + order2.GetPackingLabel());
        Console.WriteLine($"\nTotal Cost: ${order2.CalculateTotalCost():F2}");
    }
}