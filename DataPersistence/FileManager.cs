using Entities;

namespace DataPersistence
{
    public class FileManager
    {

        private static readonly string filePath = GetFilePath();

        private static string GetFilePath()
        {
            string baseDir = AppContext.BaseDirectory;
            string solutionRoot = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\..\"));
            return Path.Combine(solutionRoot, "DataPersistence", "ListaProductos.txt");
        }

        public List<Product> ReadProducts()
        {
            var products = new List<Product>();

            try
            {
                if (!File.Exists(filePath))
                    return products;

                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine();

                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 4 &&
                            int.TryParse(parts[0].Trim(), out int id) &&
                            double.TryParse(parts[2].Trim(), out double price) &&
                            int.TryParse(parts[3].Trim(), out int stock))
                        {
                            var product = new Product
                            {
                                Id = id,
                                Name = parts[1].Trim(),
                                Price = price,
                                Stock = stock
                            };
                            products.Add(product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return products;
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
