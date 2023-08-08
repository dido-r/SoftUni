
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context
                .Shells
                .Where(x => x.ShellWeight > shellWeight)
                .ProjectTo<ShellExportModel>(InitizliseMapper())
                .OrderBy(x => x.ShellWeight)
                .ToList();

            foreach (var shell in shells)
            {
                shell.Guns = shell.Guns.Where(x => x.GunType == "AntiAircraftGun").OrderByDescending(w => w.GunWeight).ToList();
            }

            return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context
                .Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .Select(x => new GunXmlExportModel 
                {
                    Manufacturer = manufacturer,
                    GunType = x.GunType.ToString(),
                    GunWeight = x.GunWeight,
                    BarrelLength = x.BarrelLength,
                    Range = x.Range,
                    Countries = x.CountriesGuns.Where(a => a.Country.ArmySize > 4500000).Select(c => new CountryExportModel 
                    {
                        Country = c.Country.CountryName,
                        ArmySize = c.Country.ArmySize
                    })
                    .OrderBy(z => z.ArmySize)
                    .ToArray()
                })
                .OrderBy(x => x.BarrelLength)
                .ToArray();

            var serializer = new XmlSerializer(typeof(GunXmlExportModel[]), new XmlRootAttribute("Guns"));
            var writer = new StringWriter();
            var settings = new XmlSerializerNamespaces();
            settings.Add("", "");
            serializer.Serialize(writer, guns, settings);

            return writer.ToString().Trim();
        }

        private static MapperConfiguration InitizliseMapper()
        {
            var config = new MapperConfiguration(x => x.AddProfile(new ArtilleryProfile()));
            config.CreateMapper();

            return config;
        }
    }
}
