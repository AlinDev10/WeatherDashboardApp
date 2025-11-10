using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherDashboardAPI.Application.Commands;
using WeatherDashboardAPI.Application.Queries;
using WeatherDashboardAPI.Domain.Entities;

namespace WeatherDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserEntity userEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await sender.Send(new AddUserCommand(userEntity));
                    return Ok(result);
                }
                else {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected internal server error occurred.");
            }
            
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                var result = await sender.Send(new GetAllUsersQuery());
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected internal server error occurred.");
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] string userId)
        {
            try
            {
                var result = await sender.Send(new GetUserByIdQuery(userId));
                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected internal server error occurred.");
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserEntity userEntity)
        {
            try
            {
                var result = await sender.Send(new UpdateUserCommand(userEntity));
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected internal server error occurred.");
            }

        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] string userId)
        {
            try
            {
                var result = await sender.Send(new DeleteUserCommand(userId));
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected internal server error occurred.");
            }
        }
    }
}
