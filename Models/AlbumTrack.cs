namespace Web_Music_v3.Models
{
    public class AlbumTrack
    {
        public int Id { get; set; }
        public int Album_Id { get; set; }
        public int Track_Id { get; set; }

        public Album Album { get; set; }
        public Track Track { get; set; }
    }
}
