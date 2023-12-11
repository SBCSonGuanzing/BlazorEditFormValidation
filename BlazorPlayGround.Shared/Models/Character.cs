using System.ComponentModel.DataAnnotations;

namespace BlazorPlayGround.Shared.Models
{
    public class Character
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please, give this character a Name ")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please, give this a Bio ")]

        public string Bio { get; set; } = string.Empty;

        public DateTime? BirthDate { get; set; } = DateTime.Now;

        public string Image { get; set; } = string.Empty;

        public Team Team { get; set; }

        public int TeamId { get; set; }

        public Difficulty Difficulty { get; set; }

        public int DifficultyId { get; set; }

        public bool isReadyToFight { get; set; } = default;

    }
}
