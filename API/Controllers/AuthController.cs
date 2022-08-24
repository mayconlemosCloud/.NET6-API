using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IServiceToken _serviceToken;

        public AuthController(IServiceToken serviceToken)
        {
            _serviceToken = serviceToken;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User obj)
        {
            try
            {
                var response = _serviceToken.GenerateToken(obj);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}