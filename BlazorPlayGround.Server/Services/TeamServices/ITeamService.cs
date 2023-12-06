namespace BlazorPlayGround.Server.Services.TeamServices
{
    public interface ITeamService
    {
        // Get all Team
        Task<List<Team>> GetAllTeam();
        Task<Team> GetSingleTeam (int id);

        Task<List<Team>> DeleteTeam(int id);
        Task<List<Team>> AddTeam(Team team);
        Task<List<Team>> UpdateTeam(int id, Team team);

    }
}
