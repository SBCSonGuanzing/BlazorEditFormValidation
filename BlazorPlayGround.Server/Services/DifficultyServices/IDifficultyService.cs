namespace BlazorPlayGround.Server.Services.DifficultyServices
{
    public interface IDifficultyService
    {
        Task<List<Difficulty>> GetDifficulty();
        Task<Difficulty> GetSingleDifficulty(int id);

        Task<List<Difficulty>> DeleteDifficulty (int id);
        Task<List<Difficulty>> AddDifficulty (Difficulty difficulty);
        Task<List<Difficulty>> UpdateDifficulty (int id, Difficulty difficulty);

    }
}
