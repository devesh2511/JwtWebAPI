using JwtWebAPI;
using JwtWebAPI.Services;
using JwtWebAPI.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<UserDatabaseSettings>(
    builder.Configuration.GetSection("UserDatabase"));

builder.Services.Configure<CleaningServicesDatabaseSettings>(
    builder.Configuration.GetSection("ServicesDatabase"));

builder.Services.Configure<BookingsDatabaseSettings>(
    builder.Configuration.GetSection("BookingsDatabase"));

builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<CleaningServicesService>();
builder.Services.AddSingleton<BookingsService>();
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
 // "http://localhost:4200"
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
