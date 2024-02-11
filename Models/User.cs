using System.ComponentModel.DataAnnotations;
using Web_Music_v3.Models;

namespace Web_Music_v3.Models
{
    public class User
    {        
        public int? Id { get; set; }      
        public string Login { get; set; }        
        public string Password { get; set; }        
        public string Email { get; set; }        
        public bool IsAdmin { get; set; }

        public ICollection<PlaylistUser>? PlaylistUsers { get; set; }
        public ICollection<AlbumUser>? AlbumUsers { get; set; }

    }
}
