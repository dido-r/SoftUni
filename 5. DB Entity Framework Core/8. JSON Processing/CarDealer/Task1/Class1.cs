using AutoMapper;
using CarDealer;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public static class SuppliersImport
    {
        //string inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersDto = JsonConvert.DeserializeObject<HashSet<SupplierImportDto>>(inputJson);
            var config = new MapperConfiguration(x => x.AddProfile(new CarDealerProfile()));
            var mapper = config.CreateMapper();
            var suppliers = mapper.Map<HashSet<Supplier>>(suppliersDto);


            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}.";
        }
    }
}
