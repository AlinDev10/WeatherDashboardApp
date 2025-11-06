using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherDashboardAPI.Application.Commands;
using WeatherDashboardAPI.Application.Queries;
using WeatherDashboardAPI.Domain.Entities;

namespace WeatherDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteCitiesController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddFavoriteCityAsync([FromBody] FavoriteCitiesEntity favoriteCitiesEntity)
        {
            var result = await sender.Send(new AddFavoriteCityCommand(favoriteCitiesEntity));
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllFavoriteCitiesAsync()
        {
            var result = await sender.Send(new GetAllFavoriteCitiesQuery());
            return Ok(result);
        }


        [HttpGet("{favoriteCityId}")]
        public async Task<IActionResult> GetFavoriteCityByIdAsync([FromRoute] string favoriteCityId)
        {
            var result = await sender.Send(new GetFavoriteCityByIdQuery(favoriteCityId));
            return Ok(result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateFavoriteCityAsync([FromBody] FavoriteCitiesEntity favoriteCitiesEntity)
        {
            var result = await sender.Send(new UpdateFavoriteCityCommand(favoriteCitiesEntity));
            return Ok(result);
        }

        [HttpDelete("{favoriteCityId}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] string favoriteCityId)
        {
            var result = await sender.Send(new DeleteFavoriteCityCommand(favoriteCityId));
            return Ok(result);
        }
    }
}
