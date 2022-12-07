namespace repository.casa.popular.Repositories
{
    using domain.casa.popular.Entities;
    using repository.casa.popular.Context;
    using repository.casa.popular.Infraestructure;

    public interface IFamiliaRepository : IRepositoryBase<Familia> { }

    public class FamiliaRepository : RepositotyBase<Familia>, IFamiliaRepository
    {
        public FamiliaRepository(CasaPopularDbContext dbContext) : base(dbContext) { }
    }

}
