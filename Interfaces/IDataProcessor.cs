using System.Data;
using EmployeeServiceAPI.Models;

namespace EmployeeServiceAPI.Interfaces
{
    public interface IDataProcessor
    {
        Product ProcessData(string item, string price);
        DataTable CreateProductTable(Product product);
    }
}
