using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Interfaces;
using WebApi.Filters;
using APIModels.InputModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult CreateUser([FromBody] UserRequest received)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdUser = _userLogic.CreateUser(received);

            return CreatedAtAction(nameof(CreateUser), new { id = createdUser.Id }, createdUser);
        
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var result = _userLogic.GetAllUsers();
            return Ok(result);
        }
    }
}
