namespace repository.casa.popular.Context
{
    using domain.casa.popular.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection.Emit;

    public class CasaPopularDbContext : DbContext
    {
        public CasaPopularDbContext(DbContextOptions<CasaPopularDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Familia> Familias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CasaPopularDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
