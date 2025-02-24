using CalendarAPI.Models;
using CalendarAPI.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CalendarController : ControllerBase
{
    private readonly IVisitService _visitService;
    private readonly ILogger<CalendarController> _logger;

    public CalendarController(IVisitService visitService, ILogger<CalendarController> logger)
    {
        _visitService = visitService;
        _logger = logger;
    }

    [HttpGet("visits")]
    public async Task<IActionResult> GetVisits()
    {
        try
        {
            _logger.LogInformation("Getting all visits");
            var visits = await _visitService.GetVisitsAsync();
            return Ok(visits);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting visits");
            return StatusCode(500, "Internal server error while fetching visits");
        }
    }

    [HttpPost("visits")]
    public async Task<IActionResult> AddVisit([FromBody] Visit visit)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation($"Adding visit for country: {visit.Country}");
            var addedVisit = await _visitService.AddVisitAsync(visit);
            _logger.LogInformation($"Successfully added visit with ID: {addedVisit.Id}");

            return CreatedAtAction(
                nameof(GetVisits),
                new { id = addedVisit.Id },
                addedVisit
            );
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid visit data");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding visit");
            return StatusCode(500, "Internal server error while adding visit");
        }
    }

    [HttpDelete("visits/{id}")]
    public async Task<IActionResult> DeleteVisit(int id)
    {
        try
        {
            _logger.LogInformation($"Attempting to delete visit with ID: {id}");
            var result = await _visitService.DeleteVisitAsync(id);

            if (!result)
            {
                _logger.LogWarning($"Visit with ID {id} not found");
                return NotFound($"Visit with ID {id} not found");
            }

            _logger.LogInformation($"Successfully deleted visit with ID: {id}");
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error deleting visit with ID: {id}");
            return StatusCode(500, "Internal server error while deleting visit");
        }
    }
}