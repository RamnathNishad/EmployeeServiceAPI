using System;
using System.Data;
using EmployeeServiceAPI.Models;
using EmployeeServiceAPI.Interfaces;
using EmployeeServiceAPI;

namespace EmployeeServiceAPI
{
    public class DataProcessor : IDataProcessor
    {
        public Product ProcessData(string item, string price)
        {
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrWhiteSpace(price))
                throw new ArgumentNullException(nameof(price));

            var product = new Product
            {
                Item = item.Trim(),
                Price = ParsePrice(price)
            };

            var table = CreateProductTable(product);
            PrintTableData(table);

            return product;
        }

        public DataTable CreateProductTable(Product product)
        {
            var table = new DataTable();
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Price", typeof(double));
            table.Rows.Add(product.Item, product.Price);
            return table;
        }

        private double ParsePrice(string price)
        {
            if (!double.TryParse(price.Trim(), out double priceValue))
                throw new FormatException($"Unable to parse price value: {price}");
            
            return priceValue;
        }

        private void PrintTableData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"Item: {row["Item"]}, Price: {row["Price"]}");
            }
        }
    }
}

// Example usage
class Demo
{
    static void Main()
    {
        string item = "  Apple  ";
        string price = "  1.50  ";
        var processor = new DataProcessor();
        processor.ProcessData(item, price);
    }
}