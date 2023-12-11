using Azure.Core;
using BlazorPlayGround.Shared.DTOs;
using BlazorPlayGround.Shared.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorPlayGround.Server.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private readonly DataContext _context;
        public CharacterService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Character>> AddCharacter(CharacterDTO character)
        {
            var newCharacter = new Character()
            {
                Name = character.Name,
                Bio = character.Bio,
                BirthDate = character.BirthDate,
                Image = character.Image,
                TeamId = character.TeamId,
                DifficultyId = character.DifficultyId
            };

            _context.Add(newCharacter);
            await _context.SaveChangesAsync();
            return await GetAllCharacters();
        }

        public async Task<List<Character>> DeleteCharacter(int id)
        {
            var character = await _context.Characters
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            if (character is null)
                return null;

            _context.Remove(character);
            await _context.SaveChangesAsync();
            return await _context.Characters.ToListAsync();
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            var heroes = await _context.Characters
                .Include(p => p.Team)
                .Include(p => p.Difficulty)
                .ToListAsync();
            return heroes;
        }

        public async Task<Character> GetSingleCharacter(int id)
        {
            var character = await _context.Characters
                    .Include(p => p.Team)
                    .Include(p => p.Difficulty)
                     .Where(p => p.Id == id)
                     .FirstOrDefaultAsync();
            if (character == null)
            { 
                return null;
            }

            return character;
        }

        public async Task<List<Character>> UpdateCharacter(int id, Character request)
        {
            var character = await _context.Characters
                .Where(character => character.Id == id)
                .FirstOrDefaultAsync();

            if (character == null)
                return null;

            character.Name = request.Name;
            character.Bio = request.Bio;
            character.BirthDate = request.BirthDate;
            character.Image = request.Image;
            character.TeamId = request.TeamId;
            character.DifficultyId = request.DifficultyId;
            character.isReadyToFight = request.isReadyToFight;

            await _context.SaveChangesAsync();

            return await GetAllCharacters();
        }



    }
}
