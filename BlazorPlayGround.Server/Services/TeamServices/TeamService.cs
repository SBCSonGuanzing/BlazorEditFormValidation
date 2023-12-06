using BlazorPlayGround.Shared.Models;

using Azure.Core;

namespace BlazorPlayGround.Server.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        // Inject Data Context to Service 

        private readonly DataContext _context;
        public TeamService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> AddTeam(Team team)
        {
            var newTeam = new Team() 
            { 
                Name = team.Name,
            };

            _context.Add(newTeam);
            await _context.SaveChangesAsync();
            return await GetAllTeam();
        }

        // Delete a Team
        public async Task<List<Team>>? DeleteTeam(int id)
        {
            var hero = await _context.Teams
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            if (hero is null)
                return null;

            _context.Remove(hero);
            await _context.SaveChangesAsync();
            return await GetAllTeam();

        }

        // Get all the Team
        public async Task<List<Team>> GetAllTeam()
        {
            var heroes = await _context.Teams.ToListAsync();
            return heroes;
        }

        public async Task<Team> GetSingleTeam(int id)
        {
            var hero = await _context.Teams
                     .Where(p => p.Id == id)
                     .FirstOrDefaultAsync();
            if (hero == null)
                return null;

            return hero;
        }

        public async Task<List<Team>> UpdateTeam(int id, Team request)
        {
            var teams = await _context.Teams
                .Where(team => team.Id == id)
                .FirstOrDefaultAsync();

            if (teams == null)
                return null;

            teams.Name = request.Name;

            await _context.SaveChangesAsync();

            return await GetAllTeam();
        }
    }
}
