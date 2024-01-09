using FMA.Startup;
using FMA.Persistence;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices(true);

await app.ConfigurePipelineAsync(builder,args);
