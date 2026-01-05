using App.Dto;
using Microsoft.AspNetCore.Mvc;

namespace NetDocker.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class SigninController : ControllerBase
    {
        private readonly ILogger<SigninController> _logger;
        public SigninController(ILogger<SigninController> logger)
        {
            _logger = logger;
        }


        [HttpGet("login")]
        public async Task<ActionResult<bool>> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            await Task.Delay(1000);
            return Ok(true);
        }

    }
}