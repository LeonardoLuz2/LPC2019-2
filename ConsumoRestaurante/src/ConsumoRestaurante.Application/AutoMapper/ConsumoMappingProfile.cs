using AutoMapper;
using ConsumoRestaurante.Application.ViewModels;
using ConsumoRestaurante.Domain.Entities;

namespace ConsumoRestaurante.Application.AutoMapper
{
    public class ConsumoMappingProfile : Profile
    {
        public ConsumoMappingProfile()
        {
            CreateMap<ConsumoViewModel, Consumo>()
                .ForMember(p => p.Id, x => x.Ignore())
                .AfterMap((viewModel, model) => viewModel.Id = model.Id);

            CreateMap<Consumo, ConsumoViewModel>();
        }
    }
}
