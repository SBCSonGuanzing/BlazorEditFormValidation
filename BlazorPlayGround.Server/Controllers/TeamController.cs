using BlazorPlayGround.Server.Services.TeamServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorPlayGround.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // Get all Teams 
        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetAllTeam()
        {
            return await _teamService.GetAllTeam();
        }

        // Delete a Hero
        [HttpDelete("delete-team/{id}")]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var result = await _teamService.DeleteTeam(id);
            if (result is null)
            {
                return NotFound("Hero not found");
            }

            return Ok(result);
        }
        // Update a Hero
        [HttpPut("update-team/{id}")]
        public async Task<ActionResult<List<Team>>> UpdateTeam(int id, Team request)
        {
            var result = await _teamService.UpdateTeam(id, request);
            if (result is null)
                return NotFound("Hero not found.");
            return Ok(result);
        }

        // Add a SuperHero 
        [HttpPut]
        public async Task<ActionResult<Team>> AddTeam(Team team)
        {
            var result = await _teamService.AddTeam(team);

            return Ok(result);
        }


        // Get a Single SuperHero 
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetSingleTeam(int id)
        {
            var result = await _teamService.GetSingleTeam(id);
            if (result is null)
                return NotFound("Hero not found.");
            return Ok(result);
        }

    }
}
