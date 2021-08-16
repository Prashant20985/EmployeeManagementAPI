using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int IdEmp { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }
        [Required]
        public string Photo { get; set; }
    }
}
