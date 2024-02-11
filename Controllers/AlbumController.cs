using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using Web_Music_v3.Data;
using Web_Music_v3.Models;
using Web_Music_v3.Models.Helper;
using Web_Music_v3.Repository.Interfaces;

namespace Web_Music_v3.Controllers
{
    public class AlbumController : Controller
    {        
        private readonly DataContext _context;

        public AlbumController(DataContext context)
        {           
            _context = context;
        }

        public IActionResult List()
        {
            var album = _context.Album.ToList();
            return View("~/Views/Album/List.cshtml", album);
        } 
        
        public IActionResult CreateView() => View("~/Views/Album/Create.cshtml");

        public IActionResult CreateAlbum(Album album)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            var alb = _context.Album.Where(x => x.Title == album.Title).FirstOrDefault();
            if (alb == null)
            {
                Album albumadd = new Album()
                {
                    Title = album.Title,
                    Author = album.Author,
                    IsVisible = album.IsVisible,
                    User_Id = userId
                };                

                _context.Album.Add(albumadd);
                _context.SaveChanges();

                var albunAddNow = _context.Album.Where(x => x.Title == albumadd.Title).FirstOrDefault();

                AlbumUser albumUseradd = new AlbumUser()
                {
                    User_Id = userId,
                    Album_Id = albunAddNow.Id
                };

                _context.AlbumUser.Add(albumUseradd);
                _context.SaveChanges();

                return RedirectToAction("List", "Album");
            }
            else
            {
                ModelState.AddModelError("error_createAlbum", "Альбом с таким названием уже существует!");
                return CreateView();
            }            
        }

        public IActionResult Search(string search)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (search != null)
            {                
                var album = _context.Album.Where(x => x.Title.Contains(search) || x.Author.Contains(search)).ToList();
                
                return View("~/Views/Album/List.cshtml", album);
            }
            else
            {
                return List();
            }

        }
    }
}
