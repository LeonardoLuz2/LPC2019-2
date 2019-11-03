using AutoMapper;

namespace ConsumoRestaurante.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RestauranteMappingProfile());
                cfg.AddProfile(new ConsumoMappingProfile());
            });
        }
    }
}
