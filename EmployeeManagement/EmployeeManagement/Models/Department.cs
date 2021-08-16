using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int IdDept { get; set; }
        [Required(ErrorMessage ="Department name is required")]
        [MaxLength(30, ErrorMessage ="Max Length Is 30")]
        public string DeptName { get; set; }
    }
}
