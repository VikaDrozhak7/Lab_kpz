using System;
using System.Collections.Generic;

public interface IMoney
{
    int WholePart { get; set; }
    int FractionalPart { get; set; }
    string Currency { get; set; }
    string Display();
}

public class Money : IMoney
{
    public int WholePart { get; set; }
    public int FractionalPart { get; set; }
    public string Currency { get; set; }

    public Money(int wholePart, int fractionalPart, string currency)
    {
        WholePart = wholePart;
        FractionalPart = fractionalPart;
        Currency = currency;
    }

    public string Display()
    {
        return $"{WholePart}.{FractionalPart} {Currency}";
    }
}

public class Category
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Department { get; set; }

    public Category(string name, string description, string department)
    {
        Name = name;
        Description = description;
        Department = department;
    }
}

public class Product
{
    public string Name { get; set; }
    public IMoney Price { get; set; }
    public Category Category { get; set; }
    public string UnitOfMeasure { get; set; }
    public int Quantity { get; set; }
    public DateTime LastDeliveryDate { get; set; }

    public Product(string name, IMoney price, Category category, string unitOfMeasure, int quantity, DateTime lastDeliveryDate)
    {
        Name = name;
        Price = price;
        Category = category;
        UnitOfMeasure = unitOfMeasure;
        Quantity = quantity;
        LastDeliveryDate = lastDeliveryDate;
    }

    public void ReducePrice(int amount)
    {
        if (Price.WholePart < amount)
        {
            throw new Exception("The reduction amount cannot be greater than the product price.");
        }
        Price.WholePart -= amount;
    }
}

public class Warehouse
{
    private List<Product> Products { get; set; }

    public Warehouse()
    {
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        Products.Add(product);
    }

    public List<Product> GetProducts()
    {
        return Products;
    }
}

public class ShoppingCart
{
    private List<Product> Products { get; set; }

    public ShoppingCart()
    {
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        Products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        Products.Remove(product);
    }

    public IMoney TotalCost()
    {
        int totalWholePart = 0;
        int totalFractionalPart = 0;
        string currency = Products[0].Price.Currency;

        foreach (var product in Products)
        {
            totalWholePart += product.Price.WholePart;
            totalFractionalPart += product.Price.FractionalPart;
        }

        return new Money(totalWholePart, totalFractionalPart, currency);
    }
}

public class Reporting
{
    public Warehouse Warehouse { get; set; }

    public Reporting(Warehouse warehouse)
    {
        Warehouse = warehouse;
    }

    public void RegisterProductReceipt(Product product, int quantity, string date)
    {
        Warehouse.AddProduct(product);
    }

    public void InventoryReport()
    {
        foreach (var product in Warehouse.GetProducts())
        {
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price.Display()}, Category: {product.Category.Name}, Unit of Measure: {product.UnitOfMeasure}, Quantity: {product.Quantity}, Last Delivery Date: {product.LastDeliveryDate}");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Creating a new Money object...");
        Money money1 = new Money(100, 50, "USD");
        Money money2 = new Money(200, 25, "USD");
        Money money3 = new Money(150, 75, "USD");
        Console.WriteLine(money1.Display());

        Console.WriteLine("Creating a new Category object...");
        Category category1 = new Category("Fruit", "Edible item", "Food");
        Category category2 = new Category("Vegetable", "Edible item", "Food");
        Category category3 = new Category("Dairy", "Edible item", "Food");

        Console.WriteLine("Creating new Product objects...");
        Product product1 = new Product("Apple", money1, category1, "Kg", 200, DateTime.Now.AddDays(-10));
        Product product2 = new Product("Milk", money2, category2, "Litre", 100, DateTime.Now.AddDays(-5));
        Product product3 = new Product("Bread", money3, category3, "Piece", 150, DateTime.Now.AddDays(-2));

        Console.WriteLine("Reducing product prices...");
        product1.ReducePrice(10);
        product2.ReducePrice(20);
        product3.ReducePrice(15);
        Console.WriteLine($"Product: {product1.Name}, Price: {product1.Price.Display()}, Category: {product1.Category.Name}");
        Console.WriteLine($"Product: {product2.Name}, Price: {product2.Price.Display()}, Category: {product2.Category.Name}");
        Console.WriteLine($"Product: {product3.Name}, Price: {product3.Price.Display()}, Category: {product3.Category.Name}");

        Console.WriteLine("Creating a new Warehouse object...");
        Warehouse warehouse = new Warehouse();

        Console.WriteLine("Adding products to the warehouse...");
        warehouse.AddProduct(product1);
        warehouse.AddProduct(product2);
        warehouse.AddProduct(product3);

        Console.WriteLine("Creating a new Reporting object...");
        Reporting reporting = new Reporting(warehouse);

        Console.WriteLine("Registering product receipts...");
        reporting.RegisterProductReceipt(product1, 10, "2024-03-05");
        reporting.RegisterProductReceipt(product2, 20, "2024-03-06");
        reporting.RegisterProductReceipt(product3, 15, "2024-03-07");

        Console.WriteLine("Generating an inventory report...");
        reporting.InventoryReport();

        ShoppingCart shoppingCart = new ShoppingCart();

        bool addingProducts = true;
        while (addingProducts)
        {
            Console.WriteLine("Enter the name of the product you want to add to the cart (or 'stop' to finish):");
            string productName = Console.ReadLine();

            if (productName.ToLower() == "stop")
            {
                addingProducts = false;
            }
            else
            {

                Product productToAdd = warehouse.GetProducts().Find(p => p.Name == productName);

                if (productToAdd != null)
                {
                    shoppingCart.AddProduct(productToAdd);
                    Console.WriteLine($"Product '{productName}' has been added to the cart.");
                }
                else
                {
                    Console.WriteLine($"Product with the name '{productName}' not found.");
                }
            }
        }

        Console.WriteLine("Displaying the total cost of the cart...");
        Console.WriteLine(shoppingCart.TotalCost().Display());
    }
}
