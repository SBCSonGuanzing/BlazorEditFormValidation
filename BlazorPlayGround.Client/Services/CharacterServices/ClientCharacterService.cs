global using BlazorPlayGround.Shared.Models;
using BlazorPlayGround.Client.Services.CharacterServices;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorPlayGround.Client.Services.CharacterServices
{
    public class ClientCharacterService : IClientCharacterService
    {
        // Constructor
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public ClientCharacterService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<Character> characters { get; set; } = new List<Character>();

        public async Task AddCharacter(Character character)
        {
            await _httpClient.PostAsJsonAsync("api/Character", character);
            _navigationManager.NavigateTo("/characters");
        }

        public async Task<List<Character>> DeleteCharacter(int id)
        {
            HttpResponseMessage? response = await _httpClient.DeleteAsync($"api/Character/{id}");

            if (response != null && response.IsSuccessStatusCode)
            {
                List<Character>? content = await response.Content.ReadFromJsonAsync<List<Character>>();
                if (content != null)
                {
                    characters = content;
                }
            }
            return characters;
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Character>>($"api/Character");
            if (result != null)
            {
                characters = result;
            }
            return result;
        }

        public async Task<Character> GetSingleCharacter(int id)
        {
            var result = await _httpClient.GetAsync($"api/Character/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Character>();
            }
            return null;
        }

        public async Task UpdateCharacter(Character character)
        {
            await _httpClient.PutAsJsonAsync($"api/Character/{character.Id}", character);
            _navigationManager.NavigateTo("/characters");
        }
    }
}
