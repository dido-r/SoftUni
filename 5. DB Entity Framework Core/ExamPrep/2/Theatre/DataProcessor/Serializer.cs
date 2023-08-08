namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context
                .Theatres
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .Select(x => new TheatreExportModel
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Sum(x => x.Price),
                    Tickets = x.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Select(t => new TicketExportModel 
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber
                    }).OrderByDescending(x => x.Price).ToList()
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToList();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context
                .Plays
                .Where(x => x.Rating <= rating)
                .Select(x => new PlayExportModel
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre,
                    Actors = x.Casts.Where(m => m.IsMainCharacter).Select(a => new CastExportModel
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{x.Title}'."
                    }).OrderByDescending(x => x.FullName).ToArray()
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToArray();

            var serialiser = new XmlSerializer(typeof(PlayExportModel[]), new XmlRootAttribute("Plays"));
            var settings = new XmlSerializerNamespaces();
            settings.Add("", "");
            var writer = new StringWriter();
            serialiser.Serialize(writer, plays, settings);

            return writer.ToString();
        }
    }
}
