using System.Collections.Generic;

namespace Music.Core
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
