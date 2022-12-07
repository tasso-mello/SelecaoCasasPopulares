namespace core.casa.popular.Implementation
{
    using AutoMapper;
    using core.casa.popular.Contracts;
    using domain.casa.popular.Extensions;
    using domain.casa.popular.Models;
    using repository.casa.popular.Repositories;
    using System;
    using System.Threading.Tasks;

    public class FamiliaCore : IFamiliaCore
    {
        private readonly IFamiliaRepository _familiaRepository;

        public FamiliaCore(IMapper mapper, IFamiliaRepository familiaRepository)
        {
            Convertions._mapper = mapper;
            _familiaRepository = familiaRepository;
        }

        public async Task<string> Get(Guid id)
            => Responses.GetResponse("Familia", (await _familiaRepository.Read(id)).ToFamiliaModel());

        public async Task<string> Get(int skip, int take)
        {
            var familias = (await _familiaRepository.Read(skip, take, GetIncludes())).Select(u => u.ToFamiliaModel());

            var registersPerPage = familias.Count();
            var totalRegisters = await _familiaRepository.Count();

            return Responses.GetObjectResponse("Familia", familias, skip, take, totalRegisters, registersPerPage);
        }

        public async Task<string> Get(string filter, int skip, int take)
        {
            var familias = (await _familiaRepository.Read(p => p.Pessoas.Any(n => n.Nome.Contains(filter)), skip, take, GetIncludes())).Select(u => u.ToFamiliaModel());
            var registersPerPage = familias.Count();
            var totalRegisters = await _familiaRepository.Count();

            return Responses.GetObjectResponse("Familia", familias, skip, take, totalRegisters, registersPerPage);
        }

        private List<string> GetIncludes()
            => new List<string> { "Pessoas" };
    }
}
