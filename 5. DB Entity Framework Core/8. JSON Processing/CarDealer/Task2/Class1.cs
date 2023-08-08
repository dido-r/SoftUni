using AutoMapper;
using CarDealer;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public static class PartsImport
    {
        //string inputJson = File.ReadAllText("../../../Datasets/parts.json");
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var partsDto = JsonConvert.DeserializeObject<HashSet<PartsImportDto>>(inputJson);

            var config = new MapperConfiguration(x => x.AddProfile(new CarDealerProfile()));
            var mapper = config.CreateMapper();
            var parts = mapper.Map<HashSet<Part>>(partsDto);

            context.Parts.AddRange(parts.Where(x => x.SupplierId > 0 && x.SupplierId < 32));
            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}.";
        }
    }
}
