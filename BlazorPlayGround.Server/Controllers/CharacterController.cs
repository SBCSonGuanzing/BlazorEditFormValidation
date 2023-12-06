using BlazorPlayGround.Server.Services.CharacterServices;
using BlazorPlayGround.Shared.DTOs;
using BlazorPlayGround.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorPlayGround.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // Get all Characters 
        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetAllCharacters()
        {
            return await _characterService.GetAllCharacters();
        }

        // Add a Character 
        [HttpPost]
        public async Task<ActionResult<Character>> AddCharacter(CharacterDTO character)
        {
            var result = await _characterService.AddCharacter(character); 

            return Ok(result);  
        }

        // Update a Character
        [HttpPut("update-character/{id}")]
        public async Task<ActionResult<List<Character>>> UpdateCharacter(int id, Character request)
        {
            var result = await _characterService.UpdateCharacter(id, request);
            if (result is null)
                return NotFound("Hero not found.");
            return Ok(result);
        }

        // Delete a Character
        [HttpDelete("delete-character/{id}")]
        public async Task<ActionResult<Character>> DeleteCharacter(int id)
        {
            var result = await _characterService.DeleteCharacter(id);
            if (result is null)
            {
                return NotFound("Hero not found");
            }

            return Ok(result);
        }


        // Get a Single SuperHero 
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetSingleCharacter(int id)
        {
            var result = await _characterService.GetSingleCharacter(id);
            if (result is null)
            {
                return NotFound("Character not found.");
            }
            return Ok(result);
        }
    }
}
