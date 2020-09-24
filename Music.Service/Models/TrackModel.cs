namespace Music.Service.Models
{
    public class TrackModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsListened { get; set; }
        public int Rating { get; set; }
    }
}
