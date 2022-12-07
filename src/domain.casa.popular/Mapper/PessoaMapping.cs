namespace domain.casa.popular.Mapper
{
    using AutoMapper;
    using domain.casa.popular.Entities;
    using domain.casa.popular.Models;

    public class PessoaMapping : Profile
    {
        public PessoaMapping()
        {
            CreateMap<Pessoa, PessoaModel>();
            CreateMap<PessoaModel, Pessoa>();
        }
    }
}