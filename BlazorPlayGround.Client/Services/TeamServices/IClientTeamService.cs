namespace BlazorPlayGround.Client.Services.TeamService
{
    public interface IClientTeamService 
    {
        List<Team> teams { get; set; }

        Task<List<Team>> GetAllTeam();
        Task DeleteTeam(int id);
        Task AddTeam(Team team);
        Task UpdateTeam(int id, Team team);
        Task<Team> GetSingleTeam(int id);
    }
}
