using System.Collections.Generic;
using System.Threading.Tasks;
using Music.Core;

namespace Music.Data
{
    public interface IMusicRepository
    {
        Task<IEnumerable<Musician>> GetMusiciansWithAlbums(string musicianName);
        Task<IEnumerable<Track>> GetTracks(int albumId);
        Task<Track> GetTrackByAlbum(int albumId, int trackId);
        Task<bool> SaveChangesAsync();
        bool HasChanges();
    }
}
