namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new PrisonerOutputModel
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(o => new OfficerOutputModel
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    }).OrderBy(n => n.OfficerName).ToList(),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(s => s.Officer.Salary)
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            return JsonConvert.SerializeObject(prisoners, Formatting.Indented).Trim();
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var array = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context
                .Prisoners
                .Where(x => array.Contains(x.FullName))
                .Select(x => new PrisonerXmlOutputModel
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails.Select(m => new MailXmlOutputModel
                    {
                        Description = string.Join("", m.Description.Reverse())
                    }).ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var serializer = new XmlSerializer(typeof(PrisonerXmlOutputModel[]), new XmlRootAttribute("Prisoners"));
            var writer = new StringWriter();
            var settings = new XmlSerializerNamespaces();
            settings.Add("", "");
            serializer.Serialize(writer, prisoners, settings);

            return writer.ToString();
        }
    }
}