using EShop.Discount.Grpc.Database;
using EShop.Discount.Grpc.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<DiscountContext>(options =>
	options.UseSqlite(connectionString: builder.Configuration.GetConnectionString("DiscountConnection")));

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.
app.MapGrpcService<DiscountService>();
//app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

#endregion

app.Run();
