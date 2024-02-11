using Web_Music_v3.Models;

namespace Web_Music_v3.Repository.Interfaces
{
    public interface IAlbumRepository
    {
        public IEnumerable<Album> List(); 
        public void Add(Album album);
    }
}
