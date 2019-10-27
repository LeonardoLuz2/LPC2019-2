using AutoMapper;
using ConsumoRestaurante.Domain.Entities;
using ConsumoRestaurante.UI.WebSite.ViewModels;

namespace ConsumoRestaurante.UI.WebSite.AutoMapper
{
    public class RestauranteMappingProfile : Profile
    {
        public RestauranteMappingProfile()
        {
            CreateMap<Restaurante, RestauranteViewModel>().ReverseMap();
        }
    }
}
