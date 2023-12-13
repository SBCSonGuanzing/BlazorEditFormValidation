using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPlayGround.Shared.DTOs
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]

        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Role is required.")]

        public string Role { get; set; }
        [Required(ErrorMessage = "FirstName is required.")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required.")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Contact is required.")]

        public string Contact { get; set; }
        [Required(ErrorMessage = "Address is required.")]

        public string Address { get; set; }
    }
}
