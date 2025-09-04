using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Represents an employee entity in the system, containing information such as employee name, salary, and department ID.
/// This model is used to store and manage employee data within the application.
/// </summary>
namespace EmployeeServiceAPI.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ename { get; set; }
        public decimal Salary { get; set; }
        public int Deptid { get; set; }
    }
}