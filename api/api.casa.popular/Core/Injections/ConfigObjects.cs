namespace api.casa.popular.Injections
{
    using Microsoft.Extensions.Options;
    using domain.casa.popular.Configurations;
    public static class ConfigObjects
    {
        public static IServiceCollection AddConfigurationsObject(this IServiceCollection services, IConfiguration configuration)
        {
            var pontuacaoSelecaoConfigurations = new PontuacaoSelecaoConfigurations();
            new ConfigureFromConfigurationOptions<PontuacaoSelecaoConfigurations>(configuration.GetSection("PontuacaoSelecaoConfigurations")).Configure(pontuacaoSelecaoConfigurations);
            services.AddSingleton(pontuacaoSelecaoConfigurations);

            return services;
        }
    }
}
