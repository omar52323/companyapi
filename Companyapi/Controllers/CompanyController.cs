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


        [HttpPost("ValidateLogin")]
        public async Task<IActionResult> Get([FromBody] UserLogin user)
        {
            var res = await _companyService.ValidateLogin(user);
            return Ok(res);
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> SaveUser([FromBody] User user)
        {
            var res = await _companyService.RegisterUser(user);
            return Ok(res);
        }

        [HttpPost("CreateCompany")]
        public async Task<IActionResult> SaveCompany([FromBody] Company company)
        {
            var res = await _companyService.RegisterCompany(company);
            return Ok(res);
        }

        [HttpPost("CreateBrand")]
        public async Task<IActionResult> SaveBrand([FromBody] Brand brand)
        {
            var res = await _companyService.RegisterBrand(brand);
            return Ok(res);
        }

        [HttpGet("GetBrands/{Id_GUID}")]
        public async Task<IActionResult> GetBrands( string Id_GUID)
        {
            var res = await _companyService.GetBrands(Id_GUID);
            return Ok(res);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> SaveProduct([FromBody] Product product)
        {
            var res = await _companyService.SaveProduct(product);
            return Ok(res);
        }

        [HttpGet("GetProducts/{Id_GUID}")]
        public async Task<IActionResult> GetProducts(string Id_GUID)
        {
            var res = await _companyService.GetProducts(Id_GUID);
            return Ok(res);
        }

        [HttpGet("GetProducts/{Id_GUID}/{Id_Brand}")]
        public async Task<IActionResult> GetProductsByBrand(string Id_GUID,string Id_Brand)
        {
            var res = await _companyService.GetProductsByBrand(Id_GUID, Id_Brand);
            return Ok(res);
        }

        [HttpPost("SaveOrder")]
        public async Task<IActionResult> SaveOrder([FromBody] Order order)
        {
            var res = await _companyService.SaveOrder(order);
            return Ok(res);
        }

        [HttpGet("GetPendingOrders/{Id_GUID}/{Id_Brand}")]
        public async Task<IActionResult> GetPendingOrders(string Id_GUID,string Id_Brand)
        {
            var res = await _companyService.GetPendingOrders(Id_GUID,Id_Brand);
            return Ok(res);
        }

        [HttpGet("GetReadyOrders/{Id_GUID}/{Id_Brand}")]
        public async Task<IActionResult> GetReadyOrders(string Id_GUID, string Id_Brand)
        {
            var res = await _companyService.GetReadyOrders(Id_GUID, Id_Brand);
            return Ok(res);
        }

        [HttpPost("ChangeOrder")]
        public async Task<IActionResult> ChangeOrder([FromBody] Order order)
        {
            var res = await _companyService.ChangeOrder(order);
            return Ok(res);
        }

        [HttpPost("ChangeProductByBrand")]
        public async Task<IActionResult> ChangeProductByBrand([FromBody] ProductByBrand productbrand)
        {
            var res = await _companyService.ChangeProductByBrand(productbrand);
            return Ok(res);
        }


    }
}
