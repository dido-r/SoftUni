namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Albums
                .Where(x => x.ProducerId == producerId)
               // .Include(x => x.Producer)
               // .Include(x => x.Songs)
               // .ThenInclude(x => x.Writer)
                .Select(x => new
                {
                    Name = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(x => new { x.Name, x.Price, x.Writer }),
                    Price = x.Songs.Sum(x => x.Price),
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums.OrderByDescending(x => x.Price))
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");//.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");//{album.Producer.Name}
                sb.AppendLine($"-Songs:");
                int count = 1;

                foreach (var song in album.Songs.OrderByDescending(x => x.Name).ThenBy(x => x.Writer).ToList())
                {
                    sb.AppendLine($"---#{count++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.Writer.Name}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context
                .Songs
                .Select(x => new
                {
                    Name = x.Name,
                    Performers = x.SongPerformers.Select(x => x.Performer.FirstName + " " + x.Performer.LastName).FirstOrDefault(),
                    Writer = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            int count = 1;

            foreach (var song in songs.Where(x => x.Duration.TotalSeconds > duration).OrderBy(x => x.Name).ThenBy(x => x.Writer).ThenBy(x => x.Performers))
            {
                sb.AppendLine($"-Song #{count++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.Writer}");
                sb.AppendLine($"---Performer: {string.Join(", ", song.Performers)}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }

            return sb.ToString().Trim();
        }
    }
}
