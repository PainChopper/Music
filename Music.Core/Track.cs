using System;

namespace Music.Core
{
    public class Track
    {
        public int Id { get; set; }
        public Album Album { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsListened { get; set; }
        public int Rating { get; set; }
    }
}
