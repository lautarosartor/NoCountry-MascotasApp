using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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
builder.Services.AddTransient<ISolicitudRepository, SolicitudRepository>();
builder.Services.AddScoped<ISolicitudService, SolicitudService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// --- Agregar los tokens de JWT ---
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,    // Significa q se tiene q firmar cuando se tiene q crear
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

app.UseHttpsRedirection();

// --- Usamos la autenticacion y autorizacion
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.EnableTryItOutByDefault());
}

//--- Usamos el CORS ---
app.UseCors("NoCountry");

app.MapControllers();

app.Run();
