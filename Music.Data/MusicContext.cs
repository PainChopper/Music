using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Music.Core;

namespace Music.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {
        }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}
