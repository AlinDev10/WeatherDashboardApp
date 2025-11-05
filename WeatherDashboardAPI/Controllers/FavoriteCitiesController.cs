using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherDashboardAPI.Application.Commands;
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
    }
}
