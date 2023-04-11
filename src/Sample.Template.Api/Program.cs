using Sample.Template.Bootstrap;
using Sample.Template.CrossCutting.Serilog;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.ConfigureServices();
    builder.Host.UseSerilog(Log.Logger);

    var app = builder.Build();

    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseMiddleware<RequestSerilLogMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}

