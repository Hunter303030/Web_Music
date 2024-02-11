using Web_Music_v3.Models;

namespace Web_Music_v3.Repository.Interfaces
{
    public interface IAlbumTrackRepository
    {
        public IEnumerable<AlbumTrack> List(int albumId);
    }
}
