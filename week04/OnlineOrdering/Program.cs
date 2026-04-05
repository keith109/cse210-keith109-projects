using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1: USA Customer
        Address addr1 = new Address("123 Maple St", "Rexburg", "ID", "USA");
        Customer cust1 = new Customer("John Doe", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "L404", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "M101", 25.50, 2));

        // Order 2: International Customer
        Address addr2 = new Address("456 Maple St", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Jane Smith", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Keyboard", "K202", 50.00, 1));
        order2.AddProduct(new Product("Monitor", "MON7", 150.00, 2));
        order2.AddProduct(new Product("HDMI Cable", "H99", 10.00, 1));

        // Display results
        Order[] orders = { order1, order2 };
        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.CalculateTotalCost():F2}");
            Console.WriteLine("---------------------------------------\n");
        }
    }
}