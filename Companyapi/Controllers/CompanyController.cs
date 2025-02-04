using Microsoft.AspNetCore.Mvc;
using Companyapi.Domain.Entities;
using Companyapi.Domain.Interfaces.Services;
namespace Companyapi.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
     


        private readonly ILogger<CompanyController> _logger;

        private readonly ICompanyService _companyService;

        public CompanyController(ILogger<CompanyController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }


        [HttpGet("ValidateLogin")]
        public async Task<IActionResult> Get([FromBody] User user)
        {
            var res = await _companyService.ValidateLogin(user);
            return Ok(res);
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> SaveUser([FromBody] User user)
        {
            var res = await _companyService.ValidateLogin(user);
            return Ok(res);
        }


    }
}
