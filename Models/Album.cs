namespace Web_Music_v3.Models
{
    public class Album
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsVisible { get; set; }
        public int User_Id { get; set; }
        public ICollection<AlbumTrack> AlbumTracks { get; set; }
        public ICollection<AlbumUser> AlbumUsers { get; set; }        
    }
}
