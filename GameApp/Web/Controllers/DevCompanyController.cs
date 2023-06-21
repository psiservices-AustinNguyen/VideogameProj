using App.Models;
using App.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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

        //Delete a development co
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDevCompany([FromServices] DeleteDevCo deleteDevCo, [FromRoute] int id)
        {
            _logger.LogInformation("Recieved DELETE request");

            try
            {
                await deleteDevCo.Execute(id);
                return Ok("Development Company Deleted!");
            }
            catch (Exception err)
            {
                _logger.LogError(err.Message);
                return StatusCode(500, err.Message);
            }
        }
    }
}
