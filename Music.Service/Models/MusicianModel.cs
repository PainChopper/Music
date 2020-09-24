using System.Collections.Generic;

namespace Music.Service.Models
{
    public class MusicianModel
    {
        public string Name { get; set; }
        public ICollection<AlbumModel> Albums  { get; set; }
    }
}
