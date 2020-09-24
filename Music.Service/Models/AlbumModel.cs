using System.Collections.Generic;

namespace Music.Service.Models
{
    public class AlbumModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TrackModel> Tracks { get; set; }
    }
}
