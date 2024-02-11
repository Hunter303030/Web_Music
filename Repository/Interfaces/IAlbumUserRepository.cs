using Web_Music_v3.Models;

namespace Web_Music_v3.Repository.Interfaces
{
    public interface IAlbumUserRepository
    {
        public IEnumerable<AlbumUser> ListUser(int userId);
        public void Add(int userId, int albumId);
        public void Delete(int userId, int albumId);
    }
}
