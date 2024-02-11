using Web_Music_v3.Models;

namespace Web_Music_v3.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Path_File { get; set; }

        public ICollection<PlaylistUser> PlaylistUsers { get; set; }
        public ICollection<AlbumTrack> AlbumTracks { get; set; }
    }
}
