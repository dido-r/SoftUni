using AutoMapper;
using CarDealer;
using CarDealer.Data;
using CarDealer.Dto.Export;
using CarDealer.Dto.Import;
using CarDealer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Methods
{
    public static class MethodClass
    {
        //var inputXml = File.ReadAllText("../../../Datasets/fileName.xml");
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SupplierImport[]), new XmlRootAttribute("Suppliers"));
            var suppliersInput = (SupplierImport[])serializer.Deserialize(new StringReader(inputXml));

            var config = new MapperConfiguration(x => x.AddProfile(new CarDealerProfile()));
            var mapper = config.CreateMapper();
            var suppliers = mapper.Map<HashSet<Supplier>>(suppliersInput);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {context.Suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(PartImport[]), new XmlRootAttribute("Parts"));
            var partsInput = (PartImport[])serializer.Deserialize(new StringReader(inputXml));

            var config = new MapperConfiguration(x => x.AddProfile(new CarDealerProfile()));
            var mapper = config.CreateMapper();
            var parts = mapper.Map<HashSet<Part>>(partsInput.Where(x => x.SupplierId > 0 && x.SupplierId < 32));

            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {context.Parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CarImport[]), new XmlRootAttribute("Cars"));
            var carsInput = (CarImport[])serializer.Deserialize(new StringReader(inputXml));
            var listOfCars = new HashSet<Car>();

            foreach (var car in carsInput)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                };

                foreach (var item in car.PartsId.Select(x => x.Id).Distinct().Where(x => x > 0 && x < 119))
                {
                    currentCar.PartCars.Add(new PartCar { PartId = item });
                }

                listOfCars.Add(currentCar);
            }

            context.Cars.AddRange(listOfCars);
            context.SaveChanges();
            return $"Successfully imported {context.Cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CustomerImport[]), new XmlRootAttribute("Customers"));
            var customerInput = (CustomerImport[])serializer.Deserialize(new StringReader(inputXml));

            var config = new MapperConfiguration(x => x.AddProfile(new CarDealerProfile()));
            var mapper = config.CreateMapper();
            var customers = mapper.Map<HashSet<Customer>>(customerInput);

            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {context.Customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SalesImport[]), new XmlRootAttribute("Sales"));
            var salesInput = (SalesImport[])serializer.Deserialize(new StringReader(inputXml));

            var config = new MapperConfiguration(x => x.AddProfile(new CarDealerProfile()));
            var mapper = config.CreateMapper();
            var sales = mapper.Map<HashSet<Sale>>(salesInput.Where(x => x.CarId > 0 && x.CarId < 36));

            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {context.Sales.Count()}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.TravelledDistance > 2000000)
                .Select(x => new CarsWithDistanceOutput
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            var writer = new StringWriter();
            var serializer = new XmlSerializer(typeof(CarsWithDistanceOutput[]), new XmlRootAttribute("cars"));
            var settings = new XmlSerializerNamespaces();
            settings.Add("", "");
            serializer.Serialize(writer, cars, settings);

            return writer.ToString();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new BmwCarsOutput
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            var writer = new StringWriter();
            var serializer = new XmlSerializer(typeof(BmwCarsOutput[]), new XmlRootAttribute("cars"));
            var settings = new XmlSerializerNamespaces();
            settings.Add("", "");
            serializer.Serialize(writer, cars, settings);

            return writer.ToString();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new LocalSuppliersOutput
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToArray();

            var writer = new StringWriter();
            var serializer = new XmlSerializer(typeof(LocalSuppliersOutput[]), new XmlRootAttribute("suppliers"));
            var settings = new XmlSerializerNamespaces();
            settings.Add("", "");
            serializer.Serialize(writer, suppliers, settings);

            return writer.ToString();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(x => new CarsWithPartsOutput
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(p => new PartOutput
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(z => z.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            var writer = new StringWriter();
            var serializer = new XmlSerializer(typeof(CarsWithPartsOutput[]), new XmlRootAttribute("cars"));
            var settings = new XmlSerializerNamespaces();
            settings.Add("", "");
            serializer.Serialize(writer, cars, settings);

            return writer.ToString();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customer = context
                 .Customers
                 .Where(x => x.Sales.Count > 0)
                 .Select(x => new CustomerWithSaleOutput
                 {
                     Name = x.Name,
                     BoughtCars = x.Sales.Count(),
                     SpentMoney = x.Sales.Select(y => y.Car).SelectMany(x => x.PartCars).Select(x => x.Part.Price).Sum()
                 })
                 .OrderByDescending(x => x.SpentMoney)
                 .ToArray();

            var serialiser = new XmlSerializer(typeof(CustomerWithSaleOutput[]), new XmlRootAttribute("customers"));
            var writer = new StringWriter();
            var settings = new XmlSerializerNamespaces();
            settings.Add("", "");
            serialiser.Serialize(writer, customer, settings);

            return writer.ToString();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(x => new SalesPriceOutput
                {
                    Car = new SoldCarOutput
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = (x.Car.PartCars.Sum(p => p.Part.Price) * (1 - x.Discount / 100))

                })
                .ToArray();

            var serialiser = new XmlSerializer(typeof(SalesPriceOutput[]), new XmlRootAttribute("sales"));
            var writer = new StringWriter();
            var settings = new XmlSerializerNamespaces();
            settings.Add("", "");
            serialiser.Serialize(writer, sales, settings);

            return writer.ToString();
        }
    }
}
