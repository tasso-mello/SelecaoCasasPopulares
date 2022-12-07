namespace api.casa.popular.Core.Injections
{
    using api.casa.popular.Core.Database;
    using domain.casa.popular.Extensions;
    using Microsoft.EntityFrameworkCore;
    using repository.casa.popular.Context;

    public static class DatabaseConf
    {
        public static IServiceCollection AddDatabaseConf(this IServiceCollection services, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlConnection").Decode();

            services.AddDbContext<CasaPopularDbContext>(options => 
                options.UseSqlServer(connectionString)
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            DbSeed.AddDatabaseWithSeed(connectionString);

            return services;
        }
    }
}