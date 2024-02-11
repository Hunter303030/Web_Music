using Microsoft.EntityFrameworkCore;
using Web_Music_v3.Data;
using Web_Music_v3.Models;
using Web_Music_v3.Repository.Interfaces;

namespace Web_Music_v3.Repository
{
    public class AlbumUserRepository : IAlbumUserRepository
    {
        private readonly DataContext _context;

        public AlbumUserRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(int userId, int albumId)
        {
            AlbumUser albumUser = new AlbumUser()
            {
                Album_Id = albumId,
                User_Id = userId
            };
            
            _context.Add(albumUser);
            _context.SaveChanges();
        }

        public void Delete(int userId, int albumId)
        {
            var albomuser = _context.AlbumUser.Where(x=>x.User_Id == userId && x.Album_Id == albumId).FirstOrDefault();
            if (albomuser != null)
            {
                _context.Remove(albomuser);
                _context.SaveChanges();
            }
        }

        public IEnumerable<AlbumUser> ListUser(int userId)
        {
            var albumUser = _context.AlbumUser.Where(x=>x.User_Id == userId).Include(x=>x.Album).ToList();
            return albumUser;
        }
    }
}
