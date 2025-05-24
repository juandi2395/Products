using Entities;

namespace DataPersistence
{
    public class FileManager
    {

        private static string filePath = Path.Combine("1_DataAccess", "ListaProductos.txt");

        public List<Product> ReadProducts()
        {
            // -- INTENTAR HACER --
            var products = new List<Product>();
            return products;

        }

        public void SaveProducts(List<Product> products)
        {


        }

        public void SaveProduct(Product product)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            int nextId = 0;

            if (!File.Exists(filePath))
            {
                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Id, Name, Price, Stock");
                    writer.WriteLine($"{nextId}, {product.Name}, {product.Price}, {product.Stock}");
                }
            }
            else
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length > 1)
                {
                    string lastLine = lines.Last();
                    string[] parts = lastLine.Split(',');
                    if (int.TryParse(parts[0].Trim(), out int lastId))
                    {
                        nextId = lastId + 1;
                    }
                }

                using (var writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine($"{nextId}, {product.Name}, {product.Price}, {product.Stock}");
                }
            }
        }

    }
    
}
