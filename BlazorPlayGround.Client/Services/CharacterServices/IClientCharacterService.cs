global using BlazorPlayGround.Shared.Models;

namespace BlazorPlayGround.Client.Services.CharacterServices
{
    public interface IClientCharacterService
    {
        List<Character> characters { get; set; }

        Task<List<Character>> GetAllCharacters();
        Task<Character> GetSingleCharacter(int id);
        Task AddCharacter(Character character);
        Task UpdateCharacter(Character character);
        Task<List<Character>> DeleteCharacter(int id);

    }
}
