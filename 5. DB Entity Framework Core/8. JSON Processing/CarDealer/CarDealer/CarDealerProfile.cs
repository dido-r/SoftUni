using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierImportDto, Supplier>();
            CreateMap<PartsImportDto, Part>();
            CreateMap<CustomerImportDto, Customer>();
            CreateMap<CarImportDto, Car>();
            CreateMap<SalesImportDto, Sale>();
        }
    }
}
