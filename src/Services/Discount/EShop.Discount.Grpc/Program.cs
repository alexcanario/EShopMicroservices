var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.
builder.Services.AddGrpc();

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

#endregion

app.Run();
