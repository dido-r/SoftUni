namespace Artillery
{
    using Artillery.Data.Models;
    using Artillery.DataProcessor.ExportDto;
    using Artillery.DataProcessor.ImportDto;
    using AutoMapper;
    using System.Linq;
    class ArtilleryProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public ArtilleryProfile()
        {
            CreateMap<CountryImportModel, Country>();
            CreateMap<ManufacturerImportModel, Manufacturer>();
            CreateMap<ShellImportModel, Shell>();
            CreateMap<GunImportModel, Gun>();
            
            CreateMap<Shell, ShellExportModel>();
            CreateMap<Gun, GunExportModel>()
                .ForMember(x => x.GunType, z => z.MapFrom(y => y.GunType.ToString()))
                .ForMember(x => x.Range, z => z.MapFrom(y => y.Range > 3000 ? "Long-range" : "Regular range"));
        }
    }
}