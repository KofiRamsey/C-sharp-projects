using System;
using System.Collections.Generic;

class InventoryManager
{
    private List<Product> products;

    public InventoryManager()
    {
        products = new List<Product>();
    }

    public void AddProduct(string name, int quantity, decimal price)
    {
        Product newProduct = new Product(name, quantity, price);
        products.Add(newProduct);
        Console.WriteLine("Product added to inventory.");
    }

    public void UpdateProductQuantity(string name, int newQuantity)
    {
        Product product = FindProductByName(name);
        if (product != null)
        {
            product.Quantity = newQuantity;
            Console.WriteLine("Product quantity updated.");
        }
        else
        {
            Console.WriteLine("Product not found in inventory.");
        }
    }

    public void GenerateInventoryReport()
    {
        Console.WriteLine("Inventory Report:");
        foreach (Product product in products)
        {
            Console.WriteLine($"Name: {product.Name}, Quantity: {product.Quantity}, Price: {product.Price:C}");
        }
    }

    private Product FindProductByName(string name)
    {
        foreach (Product product in products)
        {
            if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return product;
            }
        }
        return null;
    }
}