using Microsoft.EntityFrameworkCore;
using webAPI.Database;

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

var app = builder.Build();

//--- Usamos el CORS ---
app.UseCors("NoCountry");

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
