using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPlayGround.Shared.DTOs
{
    public class CharacterDTO
    {
        [Required(ErrorMessage = "Please, give this a name: ")]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please, give this a bio: ")]
        public string Bio { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please, give this Birth Date: ")]
        public DateTime BirthDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Please, give this character an image: ")]

        public string Image { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please, give this character a Team ID: ")]

        public int TeamId { get; set; }
        [Required(ErrorMessage = "Please, give this character a Difficulty ID: ")]
        public int DifficultyId { get; set; }
    }
}
