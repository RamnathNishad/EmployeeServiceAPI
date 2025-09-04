using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Employee Model class representing an employee entity in the system.
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