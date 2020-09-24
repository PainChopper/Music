using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Music.Core;

namespace Music.Data
{
    public class MusicRepository : IMusicRepository
    {
        private readonly MusicContext _context;

        public MusicRepository(MusicContext context) => _context = context;
        public bool HasChanges() 
            => _context.ChangeTracker.HasChanges();
        public async Task<bool> SaveChangesAsync() 
            =>  await _context.SaveChangesAsync() > 0;
        public async Task<IEnumerable<Musician>> GetMusicianWithAlbums(string musicianName)
        {
            IQueryable<Musician> query = _context.Musicians;
            if (!string.IsNullOrEmpty(musicianName))
                query = query.Where(m => m.Name.Contains(musicianName));
            query = query.Include(m => m.Albums);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetTracks(int albumId) 
            => await _context.Albums.Where(a => a.Id == albumId).SelectMany(a => a.Tracks).ToListAsync();

        public async Task<Track> GetTrackByAlbum(int albumId, int trackId) 
            => await _context.Tracks.Where(t => t.Id == trackId && t.Album.Id == albumId).FirstOrDefaultAsync();
    }
}
