using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherDashboardAPI.Application.Commands;
using WeatherDashboardAPI.Application.Queries;
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

        [HttpGet("")]
        public async Task<IActionResult> GetAllWeatherHistoriesAsync()
        {
            var result = await sender.Send(new GetAllWeatherHistoriesQuery());
            return Ok(result);
        }

        [HttpGet("{weatherHistoryId}")]
        public async Task<IActionResult> GetWeatherHistoryByIdAsync([FromRoute] string weatherHistoryId)
        {
            var result = await sender.Send(new GetWeatherHistoryByIdQuery(weatherHistoryId));
            return Ok(result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateWeatherHistoryAsync([FromBody] WeatherHistoryEntity weatherHistoryEntity)
        {
            var result = await sender.Send(new UpdateWeatherHistoryCommand(weatherHistoryEntity));
            return Ok(result);
        }

        [HttpDelete("{weatherHistoryId}")]
        public async Task<IActionResult> DeleteWeatherHistoryAsync([FromRoute] string weatherHistoryId)
        {
            var result = await sender.Send(new DeleteWeatherHistoryCommand(weatherHistoryId));
            return Ok(result);
        }
    }
}
