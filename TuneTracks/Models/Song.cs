namespace TuneTracks.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongTitle { get; set; }
        public TimeSpan Duration { get; set; }

        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }
    }
}
