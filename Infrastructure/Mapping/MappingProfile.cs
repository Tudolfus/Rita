using AutoMapper;
using Core.Models.Products;

namespace Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDB, SelectProductVM>()
                .ForMember(x => x.Value, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Label, y => y.MapFrom(z => z.Name));
        }
    }
}
