using BlazorPlayGround.Shared.DTOs;
using BlazorPlayGround.Shared.Models;

namespace BlazorPlayGround.Server.Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetSingleCharacter(int id);
        Task<List<Character>> AddCharacter(CharacterDTO character);
        Task<List<Character>> UpdateCharacter(int id, Character character);
        Task<List<Character>> DeleteCharacter(int id);

    }
}
