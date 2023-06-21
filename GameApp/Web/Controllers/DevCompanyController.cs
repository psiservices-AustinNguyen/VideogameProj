using App.Models;
using App.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevCompanyController : Controller
    {
        private readonly ILogger<DevCompanyController> _logger;
        public DevCompanyController(ILogger<DevCompanyController> logger)
        {
            _logger = logger;
        }

        //Get all Development Companies
        [HttpGet("GetAllDevCo")]
        public async Task<ActionResult<List<DevCompany>>> GetAllDevCompanies([FromServices] GetAllDevCompanies devCompany)
        {
            _logger.LogInformation("Received GET request");
            try
            {
                //Ok(await devCompany.Execute());
                return Ok(await devCompany.Execute());
            }
            catch (Exception err)
            {
                _logger.LogError(err.Message);
                return StatusCode(500, err.Message);
            }
            
        }

        //Add a development co
        [HttpPost("add")]
        public async Task<IActionResult> AddDevCompany([FromServices] AddDevCo addDevCo, [FromBody] DevCompany model)
        {
            _logger.LogInformation("Recieved POST request");
            try
            {
                await addDevCo.Execute(model);
                return Ok("Development Company Added!");
            }
            catch(Exception err)
            {
                _logger.LogError(err.Message);
                return StatusCode(500, err.Message);
            }
        }
    }
}
