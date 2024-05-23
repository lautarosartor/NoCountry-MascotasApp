using Microsoft.EntityFrameworkCore;
using webAPI.Database;
using webAPI.Repositories;
using webAPI.Repositories.Interfaces;
using webAPI.Services;
using webAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//--- Declaramos el CORS ---
builder.Services.AddCors(options =>
    options.AddPolicy("NoCountry", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()));

// Esto trae toda la configuracion que se encuentra en appsettings.json
var config = builder.Configuration;

// Vinculamos el DbContext al connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(config.GetConnectionString("AppDb")));

// --- Declaramos los Repositories y Services ---
builder.Services.AddTransient<IMascotaRepository, MascotaRepository>();
builder.Services.AddScoped<IMascotaService, MascotaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.EnableTryItOutByDefault());
}

app.UseHttpsRedirection();

app.UseAuthorization();

//--- Usamos el CORS ---
app.UseCors("NoCountry");

app.MapControllers();

app.Run();
