namespace core.casa.popular.Implementation
{
    using AutoMapper;
    using core.casa.popular.Contracts;
    using domain.casa.popular.Extensions;
    using domain.casa.popular.Models;
    using repository.casa.popular.Repositories;
    using System;
    using System.Threading.Tasks;

    public class PessoaCore : IPessoaCore
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaCore(IMapper mapper, IPessoaRepository pessoaRepository)
        {
            Convertions._mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<string> Get(Guid id)
            => Responses.GetResponse("Pessoa", (await _pessoaRepository.Read(id)).ToPessoaModel());

        public async Task<string> Get(int skip, int take)
        {
            var familias = (await _pessoaRepository.Read(skip, take, GetIncludes())).Select(u => u.ToPessoaModel());
            var registersPerPage = familias.Count();
            var totalRegisters = await _pessoaRepository.Count();

            return Responses.GetObjectResponse("Pessoa", familias, skip, take, totalRegisters, registersPerPage);
        }

        public async Task<string> Get(string filter, int skip, int take)
        {
            var familias = (await _pessoaRepository.Read(p => p.Nome.Contains(filter), skip, take, GetIncludes())).Select(u => u.ToPessoaModel());
            var registersPerPage = familias.Count();
            var totalRegisters = await _pessoaRepository.Count();

            return Responses.GetObjectResponse("Pessoa", familias, skip, take, totalRegisters, registersPerPage);
        }

        private List<string> GetIncludes()
            => new List<string> { "Familia" };
    }
}
