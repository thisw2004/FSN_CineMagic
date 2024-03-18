using CineMagicData.Models;
using CineMagicData.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CineMagicApi.Controllers;

[Route("api/movies")] 
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieRepository _movieRepo;
    private readonly ILogger<MovieController> _logger;

    public MovieController(IMovieRepository movieRepo, ILogger<MovieController> logger)
    {
        _movieRepo = movieRepo;
        _logger = logger;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddMovie(Movie movie)
    {
        try
        {
            var createdMovie = await _movieRepo.CreateMovieAsync(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.Id }, createdMovie);
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
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdateMovie(Movie movieToUpdate)
    {
        try
        {
            var existingMovie = await _movieRepo.GetMoviesByIdAsync(movieToUpdate.Id);

            if (existingMovie == null)
            {
                return NotFound(new
                {
                    StatusCode = "404",
                    message = "record not found"
                });
            }

            existingMovie.Title = movieToUpdate.Title;
            existingMovie.Description = movieToUpdate.Description;
            existingMovie.ShortDescription = movieToUpdate.ShortDescription;
            existingMovie.Image = movieToUpdate.Image;
            existingMovie.PegiRating = movieToUpdate.PegiRating;
            existingMovie.Genre = movieToUpdate.Genre;
            existingMovie.Length = movieToUpdate.Length;

            await _movieRepo.UpdateMovieAsync(existingMovie);
            return NoContent();
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

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        try
        {
            var existingMovie = await _movieRepo.GetMoviesByIdAsync(id);

            if (existingMovie == null)
            {
                return NotFound(new
                {
                    StatusCode = "404",
                    message = "record not found"
                });
            }

            await _movieRepo.DeleteMovieAsync(existingMovie);
            return NoContent();
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
    
    [HttpGet("all")]
    public async Task<IActionResult> GetMovies()
    {
        try
        {
            var movies = await _movieRepo.GetMoviesAsync();
            return Ok(movies);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { StatusCode = "500", message = ex.Message });
        }
    }
    
    
    [HttpGet("search")]
    public async Task<IActionResult> SearchMovies(
        [FromQuery] string searchTerm = null,
        [FromQuery] string pegi = null,
        [FromQuery] string genre = null)
    {
        try
        {
            var movies = await _movieRepo.SearchMoviesAsync(searchTerm, pegi, genre);
            return Ok(movies);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { StatusCode = "500", message = ex.Message });
        }
    }
    
    [HttpGet("movie/{id}")]
    public async Task<IActionResult> GetMovieById(int id)
    {
        try
        {
            var movie = await _movieRepo.GetMoviesByIdAsync(id);
            if (movie == null)
            {
                return NotFound(new { StatusCode = "404", message = "record not found" });
            }
            return Ok(movie);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { StatusCode = "500", message = ex.Message });
        }
    }

}