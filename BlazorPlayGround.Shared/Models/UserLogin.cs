using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPlayGround.Shared.Models
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role {  get; set; } 
        public UserDetails UserDetails { get; set; }
    }
}
