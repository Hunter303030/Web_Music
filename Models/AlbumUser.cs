namespace Web_Music_v3.Models
{
    public class AlbumUser
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Album_Id { get; set; }

        public User User { get; set; }
        public Album Album { get; set; }
    }
}
