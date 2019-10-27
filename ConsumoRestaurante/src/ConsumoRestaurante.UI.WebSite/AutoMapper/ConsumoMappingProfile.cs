using AutoMapper;
using ConsumoRestaurante.Domain.Entities;
using ConsumoRestaurante.UI.WebSite.ViewModels;

namespace ConsumoRestaurante.UI.WebSite.AutoMapper
{
    public class ConsumoMappingProfile : Profile
    {
        public ConsumoMappingProfile()
        {
            CreateMap<Consumo, ConsumoViewModel>().ReverseMap();
        }
    }
}
