namespace api.casa.popular.Core.Injections
{
    using core.casa.popular.Contracts;
    using core.casa.popular.Implementation;

    public static class CoreInjections
    {
        public static IServiceCollection AddCoreInjections(this IServiceCollection services)
        {
            services.AddScoped<IPessoaCore, PessoaCore>();
            services.AddScoped<IFamiliaCore, FamiliaCore>();
            services.AddScoped<ISelecaoFamiliasCore, SelecaoFamiliasCore>();

            return services;
        }
    }
}