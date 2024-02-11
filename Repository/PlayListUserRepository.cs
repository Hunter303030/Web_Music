using Web_Music_v3.Models;
using Web_Music_v3.Data;
using Web_Music_v3.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Web_Music_v3.Repository
{
    public class PlayListUserRepository : IPlayListUserRepository
    {
        private readonly DataContext _context;

        public PlayListUserRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<PlaylistUser> List(int userId)
        {
            var listuser = _context.PlaylistUser.Where(x => x.User_Id == userId).Include(x=>x.Track);

            return listuser;
        }

        public void Add(PlaylistUser playlistUser)
        {
            var trackuser = _context.PlaylistUser.Where(pl => pl.User_Id == playlistUser.User_Id && pl.Track_Id == playlistUser.Track_Id).FirstOrDefault();

            if (trackuser == null)
            {
                _context.Add(playlistUser);
                _context.SaveChanges();
            }
        }

        public void Delete(int userId, int trackId)
        {
            var trackuser = _context.PlaylistUser.Where(pl => pl.User_Id == userId && pl.Track_Id == trackId).FirstOrDefault();

            if (trackuser != null)
            {
                _context.Remove(trackuser);
                _context.SaveChanges();
            }
        }
    }
}
