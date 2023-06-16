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

        //Get all departments
        [HttpGet]
        public async Task<ActionResult<List<DevCompany>>> GetAllDevCompanies([FromServices] GetAllDevCompanies devCompany)
        {
            _logger.LogInformation("Received GET request");
            try
            {
                Ok(await devCompany.Execute());
                return Ok(200);
            }
            catch (Exception err)
            {
                _logger.LogError(err.Message);
                return StatusCode(500, err.Message);
            }
            
        }
    }
}
