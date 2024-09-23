using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using UsersService.Interfaces;
using UsersService.Services;

namespace UsersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Get User")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                var user = _userService.GetUser(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving user: {ex.Message}");
            }
        }

        [HttpPost("Add User")]
        public ActionResult<User> SetUser(User newUser)
        {
            try
            {
                if (newUser == null)
                    return BadRequest("NewUser cannot be null");

                _userService.Add(newUser);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding user: {ex.Message}");
            }
        }

        [HttpGet("Get All Users")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                var users = _userService.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving users: {ex.Message}");
            }
        }

        [HttpPut("Update User")]
        public IActionResult UpdateUser(int id, User newUser)
        {
            try
            {
                _userService.Update(id, newUser);
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating user: {ex.Message}");
            }
        }

        [HttpDelete("Delete User")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting user: {ex.Message}");
            }
        }
    }
}
