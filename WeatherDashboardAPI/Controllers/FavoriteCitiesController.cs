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
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await sender.Send(new AddFavoriteCityCommand(favoriteCitiesEntity));
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
        public async Task<IActionResult> GetAllFavoriteCitiesAsync()
        {
            try
            {
                var result = await sender.Send(new GetAllFavoriteCitiesQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Concat("An unexpected internal server error occurred: ", ex.Message));
            }
        }


        [HttpGet("{favoriteCityId}")]
        public async Task<IActionResult> GetFavoriteCityByIdAsync([FromRoute] string favoriteCityId)
        {
            try
            {
                var result = await sender.Send(new GetFavoriteCityByIdQuery(favoriteCityId));
                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Concat("An unexpected internal server error occurred: ", ex.Message));
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateFavoriteCityAsync([FromBody] FavoriteCitiesEntity favoriteCitiesEntity)
        {
            try
            {
                var result = await sender.Send(new UpdateFavoriteCityCommand(favoriteCitiesEntity));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Concat("An unexpected internal server error occurred: ", ex.Message));
            }
        }

        [HttpDelete("{favoriteCityId}")]
        public async Task<IActionResult> DeleteFavoriteCityAsync([FromRoute] string favoriteCityId)
        {
            try
            {
                var result = await sender.Send(new DeleteFavoriteCityCommand(favoriteCityId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Concat("An unexpected internal server error occurred: ", ex.Message));
            }
        }
    }
}
