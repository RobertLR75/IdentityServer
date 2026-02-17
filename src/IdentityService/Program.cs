using Duende.IdentityServer.Services;
using IdentityService;
using IdentityServer.ServiceDefaults;
using IdentityService.Pages.Account.Logout;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);


    builder.AddServiceDefaults();
    builder.Services.AddProblemDetails();
    builder.Services.AddHealthChecks();
    builder.Services.AddSingleton<IEventSink, IdentityServerEventSink>();

    LogoutOptions.ShowLogoutPrompt = false;
    LogoutOptions.AutomaticRedirectAfterSignOut = true;
    
    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));
    
    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();
    
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}