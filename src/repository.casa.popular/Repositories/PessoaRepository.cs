namespace repository.casa.popular.Repositories
{
    using domain.casa.popular.Entities;
    using repository.casa.popular.Context;
    using repository.casa.popular.Infraestructure;

    public interface IPessoaRepository : IRepositoryBase<Pessoa> { }

    public class PessoaRepository : RepositotyBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(CasaPopularDbContext dbContext) : base(dbContext) { }
    }

}
