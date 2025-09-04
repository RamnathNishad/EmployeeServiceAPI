using EmployeeServiceAPI.Data;
using EmployeeServiceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeDataAccess _dataAccess;

        public EmployeesController(IEmployeeDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _dataAccess.GetAllAsync();
            return Ok(employees);
        }

        // GET: api/Employees/5
        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _dataAccess.GetByIdAsync(id);
            if (employee is null)
                return NotFound();
            return Ok(employee!);
        }
        // POST: api/Employees
            [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            var created = await _dataAccess.AddAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = created.Id }, created);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            var updated = await _dataAccess.UpdateAsync(employee);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _dataAccess.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        // GET: api/Employees/salary-range?minSalary=50000&maxSalary=100000
        [HttpGet("salary-range")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesBySalaryRange([FromQuery] decimal minSalary, [FromQuery] decimal maxSalary)
        {
            var employees = await _dataAccess.GetBySalaryRangeAsync(minSalary, maxSalary);
            return Ok(employees);
        }
    }
}