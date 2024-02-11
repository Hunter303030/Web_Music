using Web_Music_v3.Models;

namespace Web_Music_v3.Repository.Interfaces
{
    public interface ITrackRepository
    {
        public IEnumerable<Track> List();      
        public IEnumerable<Track> List(IEnumerable<PlaylistUser> listuser);
        public void AddTrack(Track track);
        public void DeleteTrack(int trackId);
        public Track SelectTrack(int trackId);
        public void EditTrack(Track track);
    }
}
