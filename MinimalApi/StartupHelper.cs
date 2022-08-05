using DataLayer;

namespace MinimalApi;

internal static class StartupHelper
{
    public static void ConfigureServices(IServiceCollection svc)
    {
        svc.AddEndpointsApiExplorer();
        svc.AddSwaggerGen();
        svc.AddDataLayer();
    }

    public static void ConfigureApp(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            c.RoutePrefix = string.Empty;
        });

        app.MapGet("/customers/all", CustomersApi.GetAll);
        app.MapGet("/customers/{name}", CustomersApi.GetCustomer);
        app.MapPost("/customers", CustomersApi.AddNew);
        app.MapDelete("/customers/{id}", CustomersApi.Delete);
    }
}