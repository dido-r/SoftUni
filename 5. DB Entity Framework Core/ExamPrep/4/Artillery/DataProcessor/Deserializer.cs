namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using AutoMapper;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(CountryImportModel[]), new XmlRootAttribute("Countries"));
            var list = (CountryImportModel[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            foreach (var item in list)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = InitizliseMapper().Map<Country>(item);
                context.Countries.Add(country);
                sb.AppendLine(string.Format(SuccessfulImportCountry, item.CountryName, item.ArmySize));
            }
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ManufacturerImportModel[]), new XmlRootAttribute("Manufacturers"));
            var listDto = (ManufacturerImportModel[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
            var list = new List<Manufacturer>();

            foreach (var item in listDto)
            {
                if (!IsValid(item) || list.Any(x => x.ManufacturerName == item.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = InitizliseMapper().Map<Manufacturer>(item);
                list.Add(manufacturer);
                var resultData = manufacturer.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, $"{resultData[resultData.Length - 2]}, {resultData[resultData.Length - 1]}"));
            }
            context.Manufacturers.AddRange(list);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ShellImportModel[]), new XmlRootAttribute("Shells"));
            var listDto = (ShellImportModel[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            foreach (var item in listDto)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = InitizliseMapper().Map<Shell>(item);
                context.Shells.Add(shell);
                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var gunsDto = JsonConvert.DeserializeObject<HashSet<GunImportModel>>(jsonString);
            var sb = new StringBuilder();

            foreach (var item in gunsDto)
            {
                if (!IsValid(item) || !Enum.GetNames(typeof(GunType)).Any(x => x.ToString() == item.GunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = InitizliseMapper().Map<Gun>(item);
                gun.CountriesGuns = new List<CountryGun>();

                foreach (var country in item.Countries)
                {
                    gun.CountriesGuns.Add(new CountryGun { CountryId = country.Id });
                }

                context.Guns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }
            context.SaveChanges();

            return sb.ToString().Trim();
        }
        private static bool IsValid(object obj)
        {
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
        private static IMapper InitizliseMapper()
        {
            var config = new MapperConfiguration(x => x.AddProfile(new ArtilleryProfile()));
            return config.CreateMapper();
        }
    }
}
