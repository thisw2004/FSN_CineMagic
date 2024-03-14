using CineMagicData.Models;
using CineMagicData.Repositories.Show;
using Microsoft.AspNetCore.Mvc;

namespace CineMagicApi.Controllers;

[Route("api/shows")] 
[ApiController]
public class ShowController : ControllerBase
{
    private readonly IShowRepistory _showRepo;
    private readonly ILogger<RoomController> _logger;

    public ShowController(IShowRepistory showRepo, ILogger<RoomController> logger)
    {
        _showRepo = showRepo;
        _logger = logger;
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddShow(RoomMovie roomMovie)
    {
        try
        {
            var createdShow = await _showRepo.CreateShowAsync(roomMovie);
            return CreatedAtAction(nameof(GetShowById), new { id = createdShow.Id }, createdShow);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { StatusCode = "500", message = ex.Message });
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetShowById(int id)
    {
        try
        {
            var room = await _showRepo.GetShowByIdAsync(id);
            if (room == null)
            {
                return NotFound(new { StatusCode = "404", message = "record not found" });
            }
            return Ok(room);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { StatusCode = "500", message = ex.Message });
        }
    }
}