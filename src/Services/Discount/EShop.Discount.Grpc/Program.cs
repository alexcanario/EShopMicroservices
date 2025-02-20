using EShop.Discount.Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.
builder.Services.AddGrpc();

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.
//app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

#endregion

app.Run();
