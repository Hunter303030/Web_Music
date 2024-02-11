using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Web_Music_v3.Data;
using Web_Music_v3.Models;
using Web_Music_v3.Repository.Interfaces;

namespace Web_Music_v3.Controllers
{
    public class PlaylistUserController : Controller
    {        
        private readonly DataContext _context;

        public PlaylistUserController(DataContext context)
        {            
            _context = context;
        }

        public IActionResult List()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var listuser = _context.PlaylistUser.Where(x => x.User_Id == userId).Include(x => x.Track);
            return View("~/Views/PlayListUser/List.cshtml", listuser);
        }

        public ActionResult AddTrackUser(int trackId)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var trackuser = _context.PlaylistUser.Where(pl => pl.User_Id == userId && pl.Track_Id == trackId).FirstOrDefault();

            if (trackuser == null)
            {
                PlaylistUser playlist = new PlaylistUser { Track_Id = trackId, User_Id = userId };

                _context.Add(playlist);
                _context.SaveChanges();
                return RedirectToAction("List", "Track");
            }
            else
            {                
                return RedirectToAction("List", "Track");
            }
        }

        public IActionResult DeleteTrackUser(int trackId)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var trackuser = _context.PlaylistUser.Where(pl => pl.User_Id == userId && pl.Track_Id == trackId).FirstOrDefault();

            if (trackuser != null)
            {
                _context.Remove(trackuser);
                _context.SaveChanges();
            }
            return RedirectToAction("List", "PlaylistUser");
        }

        public IActionResult Search(string search)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if(search != null)
            {
                var listuser = _context.PlaylistUser.Where(x => x.Track.Title.Contains(search) || x.Track.Author.Contains(search)).Where(x=>x.User_Id == userId).Include(x=>x.Track).ToList();
                return View("~/Views/PlayListUser/List.cshtml", listuser);
            }
            else
            {
                return List();
            }
        }
    }
}
