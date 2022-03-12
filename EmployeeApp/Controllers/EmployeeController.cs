using EmployeeApp.Data.Dtos;
using EmployeeApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("add-employee")]
        public async Task<IActionResult> AddCategory([FromBody] EmployeeToAddDto model)
        {

            if (!ModelState.IsValid) return BadRequest("Request is invalid,input valid request");
            var result = await _employeeService.AddEmployee(model);

            if (!result.Item1) return BadRequest();
            return Ok("Employee successfully added");

        }

        [HttpDelete("delete-employee")]
        public async Task<IActionResult> DeleteCategory([FromQuery] string EmployeeId)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Request");

            var isDeleted = await _employeeService.DeleteEmployee(EmployeeId);
            if (!isDeleted)
            {
                return BadRequest("Employee not Deleted");
            }
            return Ok("Employee Successfully Deleted");
        }

        [HttpGet("get-all-employees")]
        public async Task<IActionResult> GeEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            if (employees == null) return NotFound("No employees found");
            return Ok(employees);
        }

        [HttpPut("update-employee")]
        public async Task<IActionResult> UpdateEmployee(string id, EmployeeToAddDto model)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Invalid request parameter");

            var employee = await _employeeService.UpdateEmployeeByIdAsync(id, model);
            if (employee == null)
            {
                return BadRequest("Employee could not be updated");
            }
            return Ok(employee);
        }


        [HttpGet("get-employee-by-Id")]
        public async Task<IActionResult> GetEmployeeById([FromQuery] string employeeId)
        {

            if (string.IsNullOrWhiteSpace(employeeId))
                return BadRequest("Invalid request parametre");
            var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
            {
                return BadRequest("Employee does not exist");
            }
            return Ok(employee);
        }
    }
}
