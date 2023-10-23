class Program
{
    static void Main()
    {
        InventoryManager inventoryManager = new InventoryManager();

        while (true)
        {
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product Quantity");
            Console.WriteLine("3. Generate Inventory Report");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter product quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.Write("Enter product price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    inventoryManager.AddProduct(name, quantity, price);
                    break;

                case "2":
                    Console.Write("Enter product name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter new quantity: ");
                    quantity = int.Parse(Console.ReadLine());
                    inventoryManager.UpdateProductQuantity(name, quantity);
                    break;

                case "3":
                    inventoryManager.GenerateInventoryReport();
                    break;

                case "4":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}