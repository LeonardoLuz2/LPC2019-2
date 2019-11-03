using AutoMapper;
using ConsumoRestaurante.Application.ViewModels;
using ConsumoRestaurante.Domain.Entities;

namespace ConsumoRestaurante.Application.AutoMapper
{
    public class RestauranteMappingProfile : Profile
    {
        public RestauranteMappingProfile()
        {
            CreateMap<RestauranteViewModel, Restaurante>()
                .ForMember(p => p.Id, x => x.Ignore())
                .AfterMap((viewModel, model) => viewModel.Id = model.Id);

            CreateMap<Restaurante, RestauranteViewModel>();
        }
    }
}
