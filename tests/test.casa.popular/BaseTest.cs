namespace test.casa.popular
{
    using api.casa.popular.Core.Database;
    using domain.casa.popular.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using repository.casa.popular.Context;

    public class BaseTest
    {

        private readonly Mock<CasaPopularDbContext> _context;
        //public readonly IConfiguration _configuration;
        public BaseTest()
        {
            _context = new Mock<CasaPopularDbContext>();
            //_configuration = Configuration.InitCofiguration();
            Configuration.InitCofiguration();
        }
    }

    public static class Configuration
    {
        public static void InitCofiguration()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Configuration
                .AddJsonFile("appsettings.test.json")
            .AddEnvironmentVariables()
            .Build();


            var connectionString = builder.Configuration.GetConnectionString("SqlConnection").Decode();

            builder.Services.AddDbContext<TestCasaPopularDbContext>(options =>
                options.UseSqlServer(connectionString)
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            DbSeed.AddDatabaseWithSeed(connectionString);
        }

        //public static void ConfigData(IConfiguration configuration)
        //{
        //    var builder = WebApplication.CreateBuilder();

        //    builder.Services.AddDatabaseConf(configuration);
        //}
    }

    public class TestCasaPopularDbContext : CasaPopularDbContext
    {
        public TestCasaPopularDbContext(DbContextOptions<CasaPopularDbContext> options) : base(options) { }
    }
}
