using ApiMiniProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiMiniProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] PersonModel data)
        {
            string jsonData = JsonSerializer.Serialize(data);
            _logger.LogInformation("The person was logged as {Person}", jsonData);
        }

    }
}
