
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Product Management Console App!");
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. View Products");
        Console.WriteLine("3. Exit");

        var option = Int32.Parse(Console.ReadLine());

        switch(option)
        {
            case 1:
                Console.WriteLine("Adding a new product...");
                // Here you would call the method to add a product
                break;
            case 2:
                Console.WriteLine("Viewing products...");
                // Here you would call the method to view products
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