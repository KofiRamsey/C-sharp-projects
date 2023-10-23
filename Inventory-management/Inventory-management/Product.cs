class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Product(string name, int quantity, decimal price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}