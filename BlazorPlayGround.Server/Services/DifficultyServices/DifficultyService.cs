using BlazorPlayGround.Shared.Models;
using Azure.Core;

namespace BlazorPlayGround.Server.Services.DifficultyServices
{
    public class DifficultyService : IDifficultyService
    {
        private readonly DataContext _context;
        public DifficultyService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Difficulty>> AddDifficulty(Difficulty difficulty)
        {
            var newDifficulty = new Difficulty()
            {
                Title = difficulty.Title,
            };

            _context.Add(newDifficulty);
            await _context.SaveChangesAsync();
            return await GetDifficulty();
        }

        public async Task<List<Difficulty>> DeleteDifficulty(int id)
        {
            var difficulty = await _context.Difficulties
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            if (difficulty is null)
                return null;

            _context.Remove(difficulty);
            await _context.SaveChangesAsync();
            return await GetDifficulty();
        }

        public async Task<List<Difficulty>> GetDifficulty()
        {
            var difficulties = await _context.Difficulties.ToListAsync();
            return difficulties;
        }

        public async Task<Difficulty> GetSingleDifficulty(int id)
        {
            var difficulties = await _context.Difficulties
                     .Where(p => p.Id == id)
                     .FirstOrDefaultAsync();
            if (difficulties == null)
                return null;

            return difficulties;
        }

        public async Task<List<Difficulty>> UpdateDifficulty(int id, Difficulty request)
        {
            var teams = await _context.Difficulties
                .Where(team => team.Id == id)
                .FirstOrDefaultAsync();

            if (teams == null)
                return null;

            teams.Title = request.Title;

            await _context.SaveChangesAsync();

            return await GetDifficulty();
        }
    }
}
