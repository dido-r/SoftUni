using AutoMapper;
using CarDealer.Dto.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierImport, Supplier>();
            CreateMap<PartImport, Part>();
            CreateMap<CarImport, Car>();
            CreateMap<CustomerImport, Customer>();
            CreateMap<SalesImport, Sale>();
        }
    }
}
