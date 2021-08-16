using EmployeeManagement.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(EmployeeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public JsonResult GetEmployees()
        {
            var result = _context.Employees.Select(x => new
                {  
                    x.IdEmp,
                    x.EmpName,
                    x.Department,
                    x.DateOfJoining,
                    x.Photo
                });
            return new JsonResult(result);
        }

        [HttpPost]
        public JsonResult PostEmployee(Employee emp)
        {
            Employee employee = new Employee
            {
                EmpName = emp.EmpName,
                Department = emp.Department,
                DateOfJoining = emp.DateOfJoining,
                Photo = emp.Photo
            };

            _context.Add(employee);
            _context.SaveChanges();

            return new JsonResult(employee);
        }

        [HttpPut]
        public JsonResult PutEmployee(Employee emp)
        {
            var result = _context.Employees.FirstOrDefault(x => x.IdEmp == emp.IdEmp);

            result.EmpName = emp.EmpName;
            result.Department = emp.Department;
            result.DateOfJoining = emp.DateOfJoining;
            result.Photo = emp.Photo;

            _context.SaveChanges();

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteEmployee(int id)
        {
            var result = _context.Employees.FirstOrDefault(x => x.IdEmp == id);

            _context.Remove(result);
            _context.SaveChanges();

            return new JsonResult(result);
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

        [Route("GetAllDepartmentNames")]
        public JsonResult GetAllDepartmentNames()
        {
            var result = _context.Departments.Select(x => new { x.DeptName, x.IdDept });

            return new JsonResult(result);
        }
    }
}
