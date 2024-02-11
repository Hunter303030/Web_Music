using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Security.Claims;
using Web_Music_v3.Data;
using Web_Music_v3.Models;
using Web_Music_v3.Models.Helper;
using Web_Music_v3.Repository.Interfaces;

namespace Web_Music_v3.Controllers
{
    public class TrackController : Controller
    {        
        private readonly DataContext _context;

        public TrackController(DataContext context)
        {            
            _context = context;
        }

        public IActionResult List()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var tracks = _context.Track.ToList();
            var albumUser = _context.AlbumUser.Where(x => x.User_Id == userId).Include(x => x.Album).ToList();
            var plUser = _context.PlaylistUser.Where(x => x.User_Id == userId).ToList();

            TracksAlbumUser tracksAlbumUser = new TracksAlbumUser()
            {
                Tracks = tracks,
                AlbumUsers = albumUser,
                PlaylistUsers= plUser
            };
            return View("~/Views/Track/List.cshtml", tracksAlbumUser);
        }        

        public IActionResult Search(string search)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (search != null)
            {
                var tracks = _context.Track.Where(x => x.Title.Contains(search) || x.Author.Contains(search)).ToList();
                var albumUser = _context.AlbumUser.Where(x => x.User_Id == userId).Include(x => x.Album).ToList();
                var plUser =  _context.PlaylistUser.Where(x => x.User_Id == userId).Include(x => x.Track);

                TracksAlbumUser tracksAlbumUser = new TracksAlbumUser()
                {
                    Tracks = tracks,
                    AlbumUsers = albumUser,
                    PlaylistUsers = plUser
                };
                 return View("~/Views/Track/List.cshtml", tracksAlbumUser);
            }
            else
            {
                return List();
            }
        }
    }
}
