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
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await sender.Send(new AddWeatherHistoryCommand(weatherHistoryEntity));
                    return Ok(result);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Concat("An unexpected internal server error occurred: ", ex.Message));
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllWeatherHistoriesAsync()
        {
            try
            {
                var result = await sender.Send(new GetAllWeatherHistoriesQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Concat("An unexpected internal server error occurred: ", ex.Message));
            }
        }

        [HttpGet("{weatherHistoryId}")]
        public async Task<IActionResult> GetWeatherHistoryByIdAsync([FromRoute] string weatherHistoryId)
        {
            try
            {
                var result = await sender.Send(new GetWeatherHistoryByIdQuery(weatherHistoryId));
                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Concat("An unexpected internal server error occurred: ", ex.Message));
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateWeatherHistoryAsync([FromBody] WeatherHistoryEntity weatherHistoryEntity)
        {
            try
            {
                var result = await sender.Send(new UpdateWeatherHistoryCommand(weatherHistoryEntity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Concat("An unexpected internal server error occurred: ", ex.Message));
            }
        }

        [HttpDelete("{weatherHistoryId}")]
        public async Task<IActionResult> DeleteWeatherHistoryAsync([FromRoute] string weatherHistoryId)
        {
            try
            {
                var result = await sender.Send(new DeleteWeatherHistoryCommand(weatherHistoryId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Concat("An unexpected internal server error occurred: ", ex.Message));
            }
        }
    }
}
