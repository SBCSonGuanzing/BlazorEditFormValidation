
using Microsoft.AspNetCore.Components;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorPlayGround.Client.Services.TeamService
{
    public class ClientTeamService : IClientTeamService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public ClientTeamService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        // Instance of Team Object
        public List<Team> teams { get; set; } = new List<Team>();

        public async Task AddTeam(Team team)
        {
            await _httpClient.PutAsJsonAsync("api/Team", team);
            _navigationManager.NavigateTo("/teams");
        }

        public async Task DeleteTeam(int id)
        {
            HttpResponseMessage? response = await _httpClient.DeleteAsync($"api/Team/delete-team/{id}");

            if (response != null && response.IsSuccessStatusCode)
            {
                List<Team>? content = await response.Content.ReadFromJsonAsync<List<Team>>();
                if (content != null)
                {
                    teams = content;
                }
            }
        }

        public async Task<List<Team>> GetAllTeam()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Team>>($"api/Team");
            if (result != null)
            {
                teams = result;
            }
            return result;
        }

        public async Task<Team> GetSingleTeam(int id)
        {
            var result = await _httpClient.GetAsync($"api/Team/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Team>();
            }
            return null;
        }

        public async Task UpdateTeam(int id, Team team)
        {
            await _httpClient.PutAsJsonAsync($"api/Team/update-team/{id}", team);
            _navigationManager.NavigateTo("/teams");
        }
    }
}
