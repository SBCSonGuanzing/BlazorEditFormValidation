using BlazorPlayGround.Server.Services.DifficultyServices;
using BlazorPlayGround.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorPlayGround.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly IDifficultyService _difficultyService;

        public DifficultyController(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        // Get all Teams 
        [HttpGet] 
        public async Task<ActionResult<List<Difficulty>>> GetAllDifficulty()
        {
            return await _difficultyService.GetDifficulty();
        }

        // Delete a Hero
        [HttpDelete("delete-difficulty/{id}")]
        public async Task<ActionResult<Difficulty>> DeleteDifficulty(int id)
        {
            var result = await _difficultyService.DeleteDifficulty(id);
            if (result is null)
            {
                return NotFound("Difficulty not found");
            }

            return Ok(result);
        }
        // Update a Hero
        [HttpPut("update-difficulty/{id}")]
        public async Task<ActionResult<List<Difficulty>>> UpdateDifficulty(int id, Difficulty request)
        {
            var result = await _difficultyService.UpdateDifficulty(id, request);
            if (result is null)
                return NotFound("Difficulty not found.");
            return Ok(result);
        }

        // Add a SuperHero 
        [HttpPut]
        public async Task<ActionResult<Difficulty>> AddDifficulty(Difficulty difficulty)
        {
            var result = await _difficultyService.AddDifficulty(difficulty);

            return Ok(result);
        }


        // Get a Single SuperHero 
        [HttpGet("{id}")]
        public async Task<ActionResult<Difficulty>> GetSingleDifficulty(int id)
        {
            var result = await _difficultyService.GetSingleDifficulty(id);
            if (result is null)
                return NotFound("Difficulty not found.");
            return Ok(result);
        }

    }
}
