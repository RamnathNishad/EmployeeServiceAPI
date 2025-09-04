using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using EmployeeServiceAPI.Models;
using EmployeeServiceAPI.Data;

public class EmployeeDataAccess : IEmployeeDataAccess
{
    private readonly EmployeeDbContext _context;

    public EmployeeDataAccess(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<Employee> AddAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> UpdateAsync(Employee employee)
    {
        var existing = await _context.Employees.FindAsync(employee.Id);
        if (existing == null) return null;

        existing.Ename = employee.Ename;
        existing.Salary = employee.Salary;
        existing.Deptid = employee.Deptid;
        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null) return false;

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Employee>> GetBySalaryRangeAsync(decimal minSalary, decimal maxSalary)
    {
        return await _context.Employees
            .Where(e => e.Salary >= minSalary && e.Salary <= maxSalary)
            .ToListAsync();
    }
}