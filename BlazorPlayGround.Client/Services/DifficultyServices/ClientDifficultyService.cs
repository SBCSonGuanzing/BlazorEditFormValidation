using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace BlazorPlayGround.Client.Services.DifficultyService
{
    public class ClientDifficultyService : IClientDifficultyService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public ClientDifficultyService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }
   
        public List<Difficulty> difficulties { get; set; } = new List<Difficulty>();

        public async Task AddDifficulty(Difficulty difficulty)
        {
            await _httpClient.PutAsJsonAsync("api/Difficulty", difficulty);
            _navigationManager.NavigateTo("/difficulties");
        } 

        public async Task<List<Difficulty>> DeleteDifficulty(int id)
        {
            HttpResponseMessage? response = await _httpClient.DeleteAsync($"api/Difficulty/delete-difficulty/{id}");

            if (response != null && response.IsSuccessStatusCode)
            {
                List<Difficulty>? content = await response.Content.ReadFromJsonAsync<List<Difficulty>>();
                if (content != null)
                {
                    difficulties = content;
                }

            }
            return difficulties;

        }

        public async Task<List<Difficulty>> GetAllDifficulty()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Difficulty>>($"api/Difficulty");
            if (result != null)
            {
                difficulties = result;
            }
            return result;
        }

        public async Task<Difficulty> GetSingleDifficulty(int id)
        {
            var result = await _httpClient.GetAsync($"api/Difficulty/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Difficulty>();
            }
            return null;
        }

        public async Task UpdateDifficulty(int id, Difficulty difficulty)
        {
            await _httpClient.PutAsJsonAsync($"api/Difficulty/update-difficulty/{id}", difficulty);
            _navigationManager.NavigateTo("/difficulties");
        }
    }
}
