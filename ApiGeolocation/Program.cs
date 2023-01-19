using ApiGeolocation.Data;
using ApiGeolocation.Entities;
using ApiGeolocation.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGeolocationContext, GeolocationContext>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
