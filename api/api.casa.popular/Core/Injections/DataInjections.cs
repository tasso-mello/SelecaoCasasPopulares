namespace api.casa.popular.Core.Injections
{
    using repository.casa.popular.Repositories;

    public static class DataInjections
    {
        public static IServiceCollection AddDataInjections(this IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IFamiliaRepository, FamiliaRepository>();

            return services;
        }
    }
}