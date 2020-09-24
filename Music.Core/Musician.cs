using System.Collections.Generic;

namespace Music.Core
{
    public class Musician
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public int CareerStartYear { get; set; }
        public ICollection<Album> Albums  { get; set; }
    }
}
