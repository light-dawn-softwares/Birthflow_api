using Birthflow_api.Api;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);


startup.ConfigureServices(builder.Services);
var app = builder.Build();


ILogger<Startup>? serviceLogger = app.Services.GetService(typeof(ILogger<Startup>)) as ILogger<Startup>;
startup.Configure(app, app.Environment, logger: serviceLogger);

app.Run();