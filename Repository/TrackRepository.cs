using Web_Music_v3.Models;
using Web_Music_v3.Data;
using Web_Music_v3.Repository.Interfaces;

namespace Web_Music_v3.Repository
{
    public class TrackRepository : ITrackRepository
    {
        private readonly DataContext _context;

        public TrackRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Track> List()
        {
            IEnumerable<Track> tracks = _context.Track.ToList();            
            return tracks;
        }

        public IEnumerable<Track> List(IEnumerable<PlaylistUser> playlistUsers)
        {
            List<Track> tracks = new();

            foreach (var item in playlistUsers)
            {
                var cur = _context.Track.Where(i => i.Id == item.Track_Id).ToList();
                tracks.AddRange(cur);
            }

            if (tracks == null)
            {
                return null;
            }
            else
            {
                return tracks;
            }
        }

        public void AddTrack(Track track)
        {
            string Path_File = "~/mp3/" + track.Path_File;

            var trackch = _context.Track.Where(x => x.Title == track.Title && x.Path_File == Path_File);
            if(trackch == null)
            {
                Track track1 = new Track
                {
                    Title = track.Title,
                    Author = track.Author,
                    Path_File = "~/mp3/" + track.Path_File
                };
                _context.Track.Add(track1);
                _context.SaveChanges();
            }            
        }

        public void DeleteTrack(int trackId)
        {
            var deltrack = _context.Track.Where(t=>t.Id == trackId).First();
            if (deltrack != null)
            {
                _context.Track.Remove(deltrack);
                _context.SaveChanges();
            }
        }

        public Track SelectTrack(int trackId)
        {
            var track = _context.Track.Where(t => t.Id == trackId).First();
            return track;
        }

        public void EditTrack(Track track)
        {
            var edittrack = _context.Track.Where(t=>t.Id == track.Id).First();
            if (edittrack != null)
            {
                edittrack.Title = track.Title;
                edittrack.Author = track.Author;                
                _context.SaveChanges();
            }
        }
    }
}
