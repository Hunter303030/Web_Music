namespace Web_Music_v3.Models.Helper
{
    public class TracksAlbumUser
    {
        public IEnumerable<Track> Tracks { get; set; }
        public IEnumerable<AlbumUser> AlbumUsers { get; set; }
        public IEnumerable<PlaylistUser> PlaylistUsers { get; set; }
    }
}
