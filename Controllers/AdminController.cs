using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Web_Music_v3.Data;
using Web_Music_v3.Models;
using Web_Music_v3.Models.Helper;
using Web_Music_v3.Repository.Interfaces;

namespace Web_Music_v3.Controllers
{
    public class AdminController : Controller
    {        
        private readonly DataContext _context;

        public AdminController(DataContext context)
        {            
            _context = context;
        }

        public IActionResult EditFlowTrackView()
        {
            var tracks = _context.Track.ToList();
            return View("~/Views/Admin/EditFlowTrack.cshtml", tracks);
        }

        public IActionResult AddTrackView() => View("~/Views/Admin/AddTrack.cshtml");

        public IActionResult AddTrack(Track track)
        {
            string Path_File = "~/mp3/" + track.Path_File;

            var trackch = _context.Track.Where(x => x.Title == track.Title || x.Path_File == Path_File).FirstOrDefault();
            if (trackch == null)
            {
                Track track1 = new Track
                {
                    Title = track.Title,
                    Author = track.Author,
                    Path_File = "~/mp3/" + track.Path_File
                };
                _context.Track.Add(track1);
                _context.SaveChanges();
                return RedirectToAction("EditFlowTrackView", "Admin");
            }
            else
            {
                ModelState.AddModelError("error", "Такое название или фалй уже существует!");
                return View("~/Views/Admin/AddTrack.cshtml");
            }
        }

        public IActionResult TrackDelete(int trackId)
        {
            var deltrack = _context.Track.Where(t => t.Id == trackId).First();
            if (deltrack != null)
            {
                _context.Track.Remove(deltrack);
                _context.SaveChanges();
            }
            return RedirectToAction("EditFlowTrackView", "Admin");
        }

        public IActionResult TrackEditView(int trackId)
        {
            var track = _context.Track.Where(t => t.Id == trackId).First();
            return View("~/Views/Admin/EditTrack.cshtml", track);
        }

        public IActionResult TrackEdit(Track track)
        {
            var trackch = _context.Track.Where(x => x.Title == track.Title).FirstOrDefault();
            if(trackch == null)
            {
                var edittrack = _context.Track.Where(t => t.Id == track.Id).First();
                if (edittrack != null)
                {
                    edittrack.Title = track.Title;
                    edittrack.Author = track.Author;
                    _context.SaveChanges();
                }
                return RedirectToAction("EditFlowTrackView", "Admin");
            }
            else
            {
                ModelState.AddModelError("error", "Такое название уже существует!");
                return TrackEditView(track.Id);
            }

        }

        public IActionResult Search(string search)
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (search != null)
            {
                var tracks = _context.Track.Where(x => x.Title.Contains(search) || x.Author.Contains(search)).ToList();
                
                return View("~/Views/Admin/EditFlowTrack.cshtml", tracks);
            }
            else
            {
                return EditFlowTrackView();
            }
        }
    }
}
