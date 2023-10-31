using APIModels.InputModels;
using APIModels.OutputModels;
using ILogic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    [ExceptionFilter]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var token = _sessionService.Authenticate(loginRequest.Email, loginRequest.Password);
            var response = new SessionResponse(token);
            return Ok(response);
        }


        [ServiceFilter(typeof(AuthenticationFilter))]
        [HttpDelete]
        public IActionResult Logout([FromHeader] Guid Authorization)
        {
            _sessionService.Logout(Authorization);
            return Ok();
        }
    }
}
