using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestLanding.DAL.SqlServer;

public static class Registrator
{
    public static IServiceCollection AddTestLandingSqlServer(this IServiceCollection services, string ConnectionString)
    {
        services.AddDbContext<TestLandingDB>(opt => opt
            .UseSqlServer(
                ConnectionString,
                o => o.MigrationsAssembly(typeof(Registrator).Assembly.FullName)));

        return services;
    }

}
