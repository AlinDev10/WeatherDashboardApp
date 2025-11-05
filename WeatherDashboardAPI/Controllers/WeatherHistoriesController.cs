using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherDashboardAPI.Application.Commands;
using WeatherDashboardAPI.Domain.Entities;

namespace WeatherDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherHistoriesController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddWeatherHistoryAsync([FromBody] WeatherHistoryEntity weatherHistoryEntity)
        {
            var result = await sender.Send(new AddWeatherHistoryCommand(weatherHistoryEntity));
            return Ok(result);
        }
    }
}
