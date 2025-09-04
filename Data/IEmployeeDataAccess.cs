using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeServiceAPI.Models;
namespace EmployeeServiceAPI.Data
{
    public interface IEmployeeDataAccess
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task<Employee?> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Employee>> GetBySalaryRangeAsync(decimal minSalary, decimal maxSalary);

    }
}