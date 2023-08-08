namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context
                .Coaches
                .Where(x => x.Footballers.Any())
                .ToArray()
                .Select(x => new CoachExportModel
                {
                    FootballersCount = x.Footballers.Count,
                    CoachName = x.Name,
                    Footballers = x.Footballers.Select(z => new FootballerXmlExportModel 
                    {
                        Name = z.Name,
                        Position = z.PositionType.ToString()
                    })
                    .OrderBy(n => n.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.FootballersCount)
                .ThenBy(x => x.CoachName)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CoachExportModel[]), new XmlRootAttribute("Coaches"));
            var writer = new StringWriter();
            var settings = new XmlSerializerNamespaces();
            settings.Add("", "");
            serializer.Serialize(writer, coaches, settings);

            return writer.ToString().Trim();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context
                .Teams
                .Include(x => x.TeamsFootballers)
                .ThenInclude(x => x.Footballer)
                .ToList()
                .Where(x => x.TeamsFootballers.Any(z => DateTime.Compare(z.Footballer.ContractStartDate, date) >= 0))
                .Select(x => new TeamExportModel
                {
                    Name = x.Name,
                    Footballers = x.TeamsFootballers
                    .Where(z => DateTime.Compare(z.Footballer.ContractStartDate, date) >= 0)
                    .OrderByDescending(z => z.Footballer.ContractEndDate)
                    .ThenBy(z => z.Footballer.Name)
                    .Select(f => new FootballerExportModel 
                    {
                        FootballerName = f.Footballer.Name,
                        ContractStartDate = f.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = f.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = f.Footballer.BestSkillType.ToString(),
                        PositionType = f.Footballer.PositionType.ToString()
                    })
                    .ToList()
                })
                .OrderByDescending(x => x.Footballers.Count)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToList();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
