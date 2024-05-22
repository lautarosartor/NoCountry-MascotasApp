using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Database
{
    //DbContext lo brinda EntityFM para poder conectarnos a la BD
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        //Aca adentro definimos las entidades q va a contener mi BD        
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Mascota> Mascotas { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Adopcion> Adopciones { get; set; }

        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Localidad> Localidades { get; set; }


        //Valores iniciales para algunas tablas
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nombre = "Lautaro",
                    Apellido = "Sartor",
                    Email = "lauty123@gmail.com",
                    Descripcion = "Probando",
                    IdRol = 1,
                    IdProvincia = 1,
                    IdLocalidad = 1
                },
                new Usuario
                {
                    Id = 2,
                    Nombre = "Gonzalo",
                    Apellido = "Diaz",
                    Email = "gonza123@gmail.com",
                    Descripcion = "Probando",
                    IdRol = 2,
                    IdProvincia = 2,
                    IdLocalidad = 2
                }
            );

            mb.Entity<Rol>().HasData(
                new Rol
                {
                    Id = 1,
                    Nombre = "Admin"
                },
                new Rol
                {
                    Id = 2,
                    Nombre = "Refugio"
                },
                new Rol
                {
                    Id = 3,
                    Nombre = "Cliente"
                }
            );

            mb.Entity<Provincia>().HasData(
                new Provincia
                {
                    Id = 1,
                    Nombre = "Santa Fe"
                },
                new Provincia
                {
                    Id = 2,
                    Nombre = "Córdoba"
                }
            );

            mb.Entity<Localidad>().HasData(
                new Localidad
                {
                    Id = 1,
                    Nombre = "Avellaneda"
                },
                new Localidad
                {
                    Id = 2,
                    Nombre = "Río Cuarto"
                }
            );

            mb.Entity<Mascota>().HasData(
                new Mascota
                {
                    Id = 1,
                    Nombre = "Firulais",
                    Edad = 2,
                    Especie = "Perro",
                    Raza = "Labrador",
                    IdUsuario = 1,
                    Descripcion = "Probandooo",
                },
                new Mascota
                {
                    Id = 2,
                    Nombre = "Michi",
                    Edad = 5,
                    Especie = "Gato",
                    Raza = "Siamez",
                    IdUsuario = 2,
                    Descripcion = "Probandooo",
                }
            );

            mb.Entity<Adopcion>().HasData(
                new Adopcion
                {
                    Id = 1,
                    IdUsuario = 1,
                    IdMascota = 1
                },
                new Adopcion
                {
                    Id = 2,
                    IdUsuario = 2,
                    IdMascota = 2
                }
            );
        }
    }
}

/*
    Para generar la base de datos, hay q ejecutar los siguientes comandos en consola: 
    Para la migracion -> dotnet ef migrations add MigracionInicial --project [nombreSolucion] --output-dir Database/Migrations
    Para aplicar las migraciones a la BD -> dotnet ef database update --project [nombreSolucion]
*/
