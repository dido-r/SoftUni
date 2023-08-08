using AutoMapper;
using CarDealer;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public static class CustomersImport
    {
        //string inputJson = File.ReadAllText("../../../Datasets/customers.json");
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersDto = JsonConvert.DeserializeObject<HashSet<CustomerImportDto>>(inputJson);

            var config = new MapperConfiguration(x => x.AddProfile(new CarDealerProfile()));
            var mapper = config.CreateMapper();
            var customers = mapper.Map<HashSet<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}.";
        }
    }
}
