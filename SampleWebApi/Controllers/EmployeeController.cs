using Microsoft.AspNetCore.Mvc;
using Sample.Infrastructure.UnitTest;
using Sample.Services;
using System;
using System.Threading.Tasks;

namespace SampleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpPost("saveEmployee")]
        public async Task<IActionResult> Save(EmployeeDTO employee)
        {
            try
            {
                return Ok(await _employeeService.Save(employee));

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("getAllEmployee")]
        public async Task<IActionResult> GetAll(string value)
        {

            try
            {
                return Ok(await _employeeService.GetAll(value));
            }

            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}