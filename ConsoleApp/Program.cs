


using BusinessLogic;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Product Management Console App!");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. View Products");
        Console.WriteLine("3. Exit");
        Console.WriteLine("Select an option:");

        var option = Int32.Parse(Console.ReadLine());
        ProductManager productManager = new ProductManager();

        switch (option)
        {
            case 1:
                Console.WriteLine("Enter product name:");
                var productName = Console.ReadLine();
                Console.WriteLine("Enter product price:");
                var productPrice = Double.Parse(Console.ReadLine());
                Console.WriteLine("Enter product stock:");
                var productStock = Int32.Parse(Console.ReadLine());

                
                var errors = productManager.validateProduct(productName, productPrice, productStock);

                if (errors.Count > 0)
                {
                    Console.WriteLine("Errors found:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error);
                    }
                }
                else
                {
                    productManager.AddProduct(productName, productPrice, productStock);
                    Console.WriteLine("Product added successfully!");
                }

                break;
            case 2:
                var list = productManager.GetProducts();

                Console.WriteLine("Id\tName\t\tPrice\tStock");
                Console.WriteLine("--------------------------------------");

                foreach (var product in list)
                {
                    Console.WriteLine($"{product.Id}\t{product.Name}\t\t{product.Price}\t{product.Stock}");
                }

                Console.WriteLine("--------------------------------------");

                break;
            case 3:
                Console.WriteLine("Exiting the application. Goodbye!");
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}