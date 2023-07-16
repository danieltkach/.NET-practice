using ApiMiniProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiMiniProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;

        public AddressController(ILogger<AddressController> logger)
        {
            _logger = logger;
        }

        // POST: api/Address
        [HttpPost]
        public void Post([FromBody] AddressModel data)
        {
            string jsonData = JsonSerializer.Serialize(data);
            _logger.LogInformation("The address was logged as {Address}", jsonData);
        }
    }
}
