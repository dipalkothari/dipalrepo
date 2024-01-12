using Microsoft.AspNetCore.Mvc;
using Sample.Domains;
using Sample.Services;
using System;
using System.Threading.Tasks;

namespace SampleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        //public async Task<IActionResult> ping()
        //{
        //    return Ok();
        //}
        private EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("addEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try
            {
                return Ok(await _employeeService.AddEmployee(employee));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPut("updateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                return Ok(await _employeeService.UpdateEmployee(employee));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpDelete("deleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            try
            {
                _employeeService.DeleteEmployee(Id);
                return Ok();
            }
          
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpDelete("getAllEmployee")]
        public async Task<IActionResult> GetAllEmployee(string value)
        {
            try
            {
                return Ok(await _employeeService.GetAllEmployee(value));
            }

            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
