using System.ComponentModel.DataAnnotations;

namespace BlazorPlayGround.Shared.Models
{
    public class Difficulty
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, give this Difficulty a Title ")]
        public string Title { get; set; } = string.Empty;
    }
}
