using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Web_Music_v3.Data;
using Web_Music_v3.Models;
using Web_Music_v3.Repository.Interfaces;

namespace Web_Music_v3.Controllers
{
    public class AlbumUserController : Controller
    {        
        private readonly DataContext _context;

        public AlbumUserController(DataContext context)
        {           
            _context = context;
        }

        public IActionResult List()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var albumUser = _context.AlbumUser.Where(x => x.User_Id == userId).Include(x => x.Album).ToList();
            return View("~/Views/Album/ListAlbumUser.cshtml", albumUser);
        }

        public IActionResult Add(int albumId)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AlbumUser albumUser = new AlbumUser()
            {
                Album_Id = albumId,
                User_Id = userId
            };

            _context.Add(albumUser);
            _context.SaveChanges();

            return List();
        }

        public IActionResult Delete(int albumId)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var albomuser = _context.AlbumUser.Where(x => x.User_Id == userId && x.Album_Id == albumId).FirstOrDefault();
            if (albomuser != null)
            {
                _context.Remove(albomuser);
                _context.SaveChanges();
            }
            return List();
        }

        public IActionResult Search(string search)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (search != null)
            {
                var album = _context.AlbumUser.Where(x => (x.Album.Title.Contains(search) || x.Album.Author.Contains(search)) &&  x.User_Id == userId).Include(x=>x.Album).ToList();

                return View("~/Views/Album/ListAlbumUser.cshtml", album);
            }
            else
            {
                return List();
            }

        }
    }
}
