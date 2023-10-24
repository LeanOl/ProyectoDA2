using APIModels.InputModels;
using Microsoft.AspNetCore.Mvc;
using Logic.Interfaces;
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
            return Ok(new { token = token, ok=true});
        }

        [ServiceFilter(typeof(AuthenticationFilter))]
        [AuthorizationFilter(RoleNeeded = "ADMIN")]
        [HttpDelete]
        public IActionResult Logout([FromHeader] Guid Authorization)
        {
            _sessionService.Logout(Authorization);
            return Ok();
        }
    }
}
