using Microsoft.EntityFrameworkCore;
using Web_Music_v3.Data;
using Web_Music_v3.Models;
using Web_Music_v3.Repository.Interfaces;

namespace Web_Music_v3.Repository
{
    public class AlbumTrackRepository : IAlbumTrackRepository
    {
        private readonly DataContext _context;

        public AlbumTrackRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<AlbumTrack> List(int albumId)
        {
            var albumtrack = _context.AlbumTrack.Where(x=>x.Album_Id == albumId).Include(x=>x.Track).ToList();

            return albumtrack;
        }
    }
}
