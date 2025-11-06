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
            var result = await sender.Send(new AddUserCommand(userEntity));
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await sender.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] string userId)
        {
            var result = await sender.Send(new GetUserByIdQuery(userId));
            return Ok(result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserEntity userEntity)
        {
            var result = await sender.Send(new UpdateUserCommand(userEntity));
            return Ok(result);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] string userId)
        {
            var result = await sender.Send(new DeleteUserCommand(userId));
            return Ok(result);
        }
    }
}
