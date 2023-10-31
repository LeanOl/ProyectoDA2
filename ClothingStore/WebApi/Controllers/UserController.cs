using Microsoft.AspNetCore.Mvc;
using Logic.Interfaces;
using WebApi.Filters;
using APIModels.InputModels;

namespace WebApi.Controllers
{
    [Route("api/users")]
    [ExceptionFilter]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserLogic _userLogic;
        public UserController(IUserLogic logic)
        {
            _userLogic = logic;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest received)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdUser = _userLogic.CreateUser(received.ToUserRequest());

            return CreatedAtAction(nameof(CreateUser), new { id = createdUser.Id }, createdUser);
        
        }

        [HttpGet]
        [AuthorizationFilter(RoleNeeded = "ADMIN")]
        public IActionResult GetAllUsers()
        {
            var result = _userLogic.GetAllUsers();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [AuthorizationFilter(RoleNeeded = "ADMIN")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            _userLogic.DeleteUser(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UserRequest received)
        {
            var result = _userLogic.UpdateUser(id, received);
            return Ok(result);
        }
    }
}
