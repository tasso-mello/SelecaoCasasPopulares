namespace domain.casa.popular.Mapper
{
    using AutoMapper;
    using domain.casa.popular.Entities;
    using domain.casa.popular.Models;

    public class FamiliaMapping : Profile
    {
        public FamiliaMapping()
        {
            CreateMap<Familia, FamiliaModel>();
            CreateMap<FamiliaModel, Familia>();
        }
    }
}