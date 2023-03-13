using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SampleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        public async Task<IActionResult> ping()
        {
            return Ok();
        }
    }
}
