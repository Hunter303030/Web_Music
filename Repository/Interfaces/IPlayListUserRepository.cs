using Web_Music_v3.Models;

namespace Web_Music_v3.Repository.Interfaces
{
    public interface IPlayListUserRepository
    {
        public IEnumerable<PlaylistUser> List(int userId);        
        public void Add(PlaylistUser playlistUser);
        public void Delete(int userId, int trackId);
    }
}
