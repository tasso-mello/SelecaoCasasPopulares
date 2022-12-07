namespace core.casa.popular.Implementation
{
    using AutoMapper;
    using core.casa.popular.Contracts;
    using domain.casa.popular.Configurations;
    using domain.casa.popular.Entities;
    using domain.casa.popular.Extensions;
    using domain.casa.popular.Models;
    using repository.casa.popular.Repositories;
    using System;
    using System.Threading.Tasks;

    public class SelecaoFamiliasCore : ISelecaoFamiliasCore
    {
        private readonly IFamiliaRepository _familiaRepository;
        private readonly PontuacaoSelecaoConfigurations _pontuacaoSelecaoConfigurations;

        public SelecaoFamiliasCore(IMapper mapper, IFamiliaRepository familiaRepository, PontuacaoSelecaoConfigurations pontuacaoSelecaoConfigurations)
        {
            Convertions._mapper = mapper;
            _familiaRepository = familiaRepository;
            _pontuacaoSelecaoConfigurations = pontuacaoSelecaoConfigurations;
        }

        public async Task<string> Get()
        {
            var familiasPontuadas = new List<SelecaoFamiliaModel>();
            var familiasSelcionadas = (await _familiaRepository.Read(f => f.Pessoas.Any() &&
                                                                     f.Pessoas.Sum(p => p.Salario) < _pontuacaoSelecaoConfigurations.RendaTotalMaxima,
                                                                     GetIncludes()))
                                      .Select(f => f.ToFamiliaModel());

            foreach (var familia in familiasSelcionadas)
            {
                var pontos = familia.Renda <= _pontuacaoSelecaoConfigurations.RendaTotalBaixa ? 
                                              _pontuacaoSelecaoConfigurations.PontosParaBaixaRenda : 
                                              _pontuacaoSelecaoConfigurations.PontosParaMaximaRenda;

                var numerosDependentes = familia.Pessoas.Count(p => p.Idade < _pontuacaoSelecaoConfigurations.IdadeMaximaDependentes);

                pontos += numerosDependentes >= _pontuacaoSelecaoConfigurations.MaximoDependentes ? _pontuacaoSelecaoConfigurations.PontosParaMaximoDependentes : 
                                                    (numerosDependentes > 0 && numerosDependentes < _pontuacaoSelecaoConfigurations.MaximoDependentes) ? _pontuacaoSelecaoConfigurations.PontosParaMinimoDependentes : 0;

                familiasPontuadas.Add(new SelecaoFamiliaModel(familia, pontos));
            }

            return Responses.GetObjectResponse("SelecaoFamilias", familiasPontuadas.OrderByDescending(f => f.Pontos));
        }

        private List<string> GetIncludes()
            => new List<string> { "Pessoas" };
    }
}
