namespace Web_Music_v3.Models
{
    public class PlaylistUser
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Track_Id { get; set; }   
               
        public Track Track { get; set; }
        public User User { get; set; }
    }
}
