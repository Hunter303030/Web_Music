using Microsoft.EntityFrameworkCore;
using Web_Music_v3.Data;
using Web_Music_v3.Models;
using Web_Music_v3.Repository.Interfaces;

namespace Web_Music_v3.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly DataContext _context;

        public AlbumRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Album album)
        {
            var alb = _context.Album.Where(x => x.Title == album.Title).FirstOrDefault();
            if (alb == null)
            {
                _context.Add(album);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Album> List()
        {
            var album = _context.Album.ToList();
            return album;
        }        
    }
}
