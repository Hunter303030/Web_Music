using Microsoft.AspNetCore.Mvc;
using Web_Music_v3.Data;
using Web_Music_v3.Models;
using Web_Music_v3.Models.Helper;
using Web_Music_v3.Repository.Interfaces;

namespace Web_Music_v3.Controllers
{
    public class AlbumTrackController : Controller
    {
        private IAlbumTrackRepository _albumTrackRepository;
        private ITrackRepository _trackRepository;
        private readonly DataContext _context;

        public AlbumTrackController(IAlbumTrackRepository albumTrackRepository, ITrackRepository trackRepository, DataContext context)
        {
            _albumTrackRepository = albumTrackRepository;
            _trackRepository = trackRepository;
            _context = context;
        }

        public IActionResult List(int albumId)
        {
            AlbumTrackHelper helper = new AlbumTrackHelper()
            {
                Track = _trackRepository.List(),
                AlbumTrack = _albumTrackRepository.List(albumId)
            };

            return View("~/Views/Album/ListTrack.cshtml", helper);
        }

        public IActionResult AddTrackInAlbum(int trackId, int albumId)
        {
            AlbumTrack albumTrack = new AlbumTrack()
            {
                Track_Id = trackId,
                Album_Id = albumId
            };

            _context.AlbumTrack.Add(albumTrack);
            _context.SaveChanges();

            return RedirectToAction("List", "Track");
        }
    }
}
