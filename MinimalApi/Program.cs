using System.Diagnostics;
using DataLayer;
using MinimalApi;

try
{
    var builder = WebApplication.CreateBuilder(args);
    StartupHelper.ConfigureServices(builder.Services);

    var app = builder.Build();
    StartupHelper.ConfigureApp(app);

    var dbInitializer = app.Services.GetRequiredService<IDbInitializer>();
    await dbInitializer.Initialize();

    await app.RunAsync();
}
catch (Exception ex)
{
    Trace.TraceError(ex.ToString());
    Environment.ExitCode = 1;
}