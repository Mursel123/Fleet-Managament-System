using FMA.Startup;


var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices(false);

await app.ConfigurePipelineAsync(builder, args);



