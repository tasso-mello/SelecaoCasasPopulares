namespace domain.casa.popular.Extensions
{
    using AutoMapper;
    using domain.casa.popular.Entities;
    using domain.casa.popular.Models;

    public static class Convertions
    {
        public static IMapper _mapper;

        #region Pessoa
        public static PessoaModel ToPessoaModel(this Pessoa pessoa)
            => _mapper.Map<PessoaModel>(pessoa);

        public static Pessoa ToPessoaEntity(this PessoaModel pessoa)
            => _mapper.Map<Pessoa>(pessoa);

        #endregion Pessoa

        #region Familia
        public static FamiliaModel ToFamiliaModel(this Familia familia)
            => new FamiliaModel
            {
                Pessoas = familia.Pessoas.Select(p => p.ToPessoaModel()),
                Renda = familia.Pessoas.Sum(s => s.Salario)
            };

        public static Familia ToFamiliaEntity(this FamiliaModel familia)
            => _mapper.Map<Familia>(familia);

        #endregion Familia
    }
}