using DataLayer.Repos;
using DataLayer.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer
{
    public static class Dependencies
    {
        public static void AddDataLayer(this IServiceCollection svc)
        {
            svc.AddOptions<DbOptions>()
                .Configure<IConfiguration>((o, c) => c.Bind("DBOptions", o));

            svc.AddSingleton<ConnectionHelper>();
            svc.AddTransient<IDbInitializer, DbInitializer>();

            svc.AddTransient(sp =>
            {
                var ch = sp.GetRequiredService<ConnectionHelper>();
                return ch.OpenNewConnection();
            });

            svc.AddScoped<UnitOfWork.UnitOfWork>();
            svc.AddTransient<IUnitOfWork>(sp =>
                sp.GetRequiredService<UnitOfWork.UnitOfWork>());

            svc.AddTransient<ICustomerRepo, CustomerRepo>();
        }
    }
}