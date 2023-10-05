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
        public IActionResult Login([FromBody] UserRequest userCreateModel)
        {
            var token = _sessionService.Authenticate(userCreateModel.Email, userCreateModel.Password);
            return Ok(new { token = token });
        }

        [ServiceFilter(typeof(AuthenticationFilter))]
        [AuthorizationFilter(RoleNeeded = "Admin")]
        [HttpDelete]
        public IActionResult Logout([FromHeader] Guid Authorization)
        {
            _sessionService.Logout(Authorization);
            return Ok();
        }
    }
}
