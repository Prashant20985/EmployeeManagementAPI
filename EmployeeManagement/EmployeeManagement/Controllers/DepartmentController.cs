using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public DepartmentController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetDept()
        {
           var result = _context.Departments.Select(x => new
            {
                x.IdDept,
                x.DeptName
            });

            return new JsonResult(result);
        }

        [HttpPost]
        public JsonResult PostDept(Department dept)
        {
            Department newDept = new Department
            {
                DeptName = dept.DeptName
            };
            _context.Departments.Add(newDept);
            _context.SaveChanges();

            return new JsonResult(newDept);
        }

        [HttpPut]
        public JsonResult PutDept(Department dept)
        {
            var result = _context.Departments.FirstOrDefault(x => x.IdDept == dept.IdDept);

            result.DeptName = dept.DeptName;

            _context.SaveChanges();

            return new JsonResult(result);
        }
        
        [HttpDelete]
        public JsonResult DeleteDept(int Id)
        {
            var result = _context.Departments.FirstOrDefault(x => x.IdDept == Id);

            _context.Remove(result);
            _context.SaveChanges();

            return new JsonResult(result);
        }
    }
}
