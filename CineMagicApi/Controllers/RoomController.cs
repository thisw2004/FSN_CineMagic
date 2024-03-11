using CineMagicData.Models;
using CineMagicData.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CineMagicApi.Controllers;

[Route("api/rooms")]
[ApiController]
public class RoomController : ControllerBase
{

    private readonly IRoomRepository _roomRepo;
    private readonly ILogger<RoomController> _logger;

    public RoomController(IRoomRepository roomRepo, ILogger<RoomController> logger)
    {
        _roomRepo = roomRepo;
        _logger = logger;
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddRoom(Room room)
    {
        try
        {
            var createdRoom = await _roomRepo.CreateRoomAsync(room);
            return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.Id }, createdRoom);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                StatusCode = "500",
                message = ex.Message
            });
        }
    }
    
    [HttpGet("room/{id}")]
    public async Task<IActionResult> GetRoomById(int id)
    {
        try
        {
            var room = await _roomRepo.GetRoomsByIdAsync(id);
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