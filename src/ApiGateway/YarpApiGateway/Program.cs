var builder = WebApplication.CreateBuilder(args);

//Route -> Cluster -> Path -> Destination of each microservice

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy")   );

var app = builder.Build();

app.MapReverseProxy();

app.Run();
