namespace BlazorPlayGround.Client.Services.DifficultyService
{
    public interface IClientDifficultyService
    {
        List<Difficulty> difficulties { get; set; }
        Task<List<Difficulty>> GetAllDifficulty();
        Task<Difficulty> GetSingleDifficulty(int id);
        Task AddDifficulty(Difficulty difficulty);
        Task UpdateDifficulty(int id, Difficulty difficulty);
        Task<List<Difficulty>> DeleteDifficulty(int id);
    }
}
