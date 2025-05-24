using DataPersistence;
using Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLogic
{
    public class ProductManager
    {
        public void AddProduct(string name, double price, int stock) 
        { 
            Product product = new Product
            {
                Name = name,
                Price = price,
                Stock = stock
            }; 

            FileManager fileManager = new FileManager();
            fileManager.SaveProduct(product);
        }

        public List<Product> GetProducts()
        {
            var list = new List<Product>();
            return list;
        }

        public List<string> validateProduct(string name, double price, int stock)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name))
                errors.Add("Product name cannot be empty.");

            if (price <= 0)
                errors.Add("Price must be greater than 0.");

            if (stock < 0)
                errors.Add("Stock cannot be negative.");

            return errors;
        }


    }
}
