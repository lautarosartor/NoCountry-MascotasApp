﻿using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
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

        public DbSet<Solicitud> Solicitudes { get; set; }

        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Localidad> Localidades { get; set; }

        
        //Valores iniciales para algunas tablas
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Rol>().HasData(
                new Rol { Id = 1, Nombre = "Admin" },
                new Rol { Id = 2, Nombre = "Refugio" },
                new Rol { Id = 3, Nombre = "Cliente" }
            );

            mb.Entity<Provincia>().HasData(
                new Provincia { Id = 1, Nombre = "Buenos Aires" },
                new Provincia { Id = 2, Nombre = "Catamarca" },
                new Provincia { Id = 3, Nombre = "Chaco" },
                new Provincia { Id = 4, Nombre = "Chubut" },
                new Provincia { Id = 5, Nombre = "Ciudad Autónoma de Buenos Aires" },
                new Provincia { Id = 6, Nombre = "Córdoba" },
                new Provincia { Id = 7, Nombre = "Corrientes" },
                new Provincia { Id = 8, Nombre = "Entre Ríos" },
                new Provincia { Id = 9, Nombre = "Formosa" },
                new Provincia { Id = 10, Nombre = "Jujuy" },
                new Provincia { Id = 11, Nombre = "La Pampa" },
                new Provincia { Id = 12, Nombre = "La Rioja" },
                new Provincia { Id = 13, Nombre = "Mendoza" },
                new Provincia { Id = 14, Nombre = "Misiones" },
                new Provincia { Id = 15, Nombre = "Neuquén" },
                new Provincia { Id = 16, Nombre = "Río Negro" },
                new Provincia { Id = 17, Nombre = "Salta" },
                new Provincia { Id = 18, Nombre = "San Juan" },
                new Provincia { Id = 19, Nombre = "San Luis" },
                new Provincia { Id = 20, Nombre = "Santa Cruz" },
                new Provincia { Id = 21, Nombre = "Santa Fe" },
                new Provincia { Id = 22, Nombre = "Santiago del Estero" },
                new Provincia { Id = 23, Nombre = "Tierra del Fuego, Antártida e Islas del Atlántico Sur" },
                new Provincia { Id = 24, Nombre = "Tucumán" }
            );

            mb.Entity<Localidad>().HasData(
                new Localidad { Id = 1, Nombre = "Avellaneda", IdProvincia = 21 },
                new Localidad { Id = 2, Nombre = "Reconquista", IdProvincia = 21 }
            );

            mb.Entity<Mascota>().HasData(
                new Mascota
                {
                    Id = 1,
                    Nombre = "Michi",
                    Meses = 3,
                    Años = 1,
                    Especie = "Gato",
                    Raza = "Gris",
                    UrlImagen = "https://w.wallhaven.cc/full/p9/wallhaven-p9gr59.jpg",
                    IdUsuario = 1,
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere eum animi saepe odio accusantium.",
                },
                new Mascota
                {
                    Id = 2,
                    Nombre = "Michifus",
                    Meses = 1,
                    Años = 2,
                    Especie = "Gato",
                    Raza = "Marmolado",
                    UrlImagen = "https://w.wallhaven.cc/full/lq/wallhaven-lqm2zl.jpg",
                    IdUsuario = 1,
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere eum animi saepe odio accusantium.",
                },
                new Mascota
                {
                    Id = 3,
                    Nombre = "Firu",
                    Meses = 1,
                    Años = 1,
                    Especie = "Perro",
                    Raza = "Aleman",
                    UrlImagen = "https://w.wallhaven.cc/full/4x/wallhaven-4xjqel.jpg",
                    IdUsuario = 1,
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere eum animi saepe odio accusantium.",
                },
                new Mascota
                {
                    Id = 4,
                    Nombre = "Firulais",
                    Meses = 2,
                    Años = 2,
                    Especie = "Perro",
                    Raza = "Callejero",
                    UrlImagen = "https://w.wallhaven.cc/full/p9/wallhaven-p9gr59.jpg",
                    IdUsuario = 1,
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere eum animi saepe odio accusantium.",
                }
            );

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash("refugio", out passwordHash, out passwordSalt);

            mb.Entity<Usuario>().HasData(
                new Usuario {
                    Id = 1,
                    Nombre = "Refugio",
                    Apellido = "SRL",
                    Email = "refugio@g.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    IdRol = 2,
                    IdProvincia = 21,
                    IdLocalidad = 1
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

/*
    Para generar la base de datos, hay q ejecutar los siguientes comandos en consola: 
    Para la migracion -> dotnet ef migrations add MigracionInicial --project [nombreSolucion] --output-dir Database/Migrations
    Para aplicar las migraciones a la BD -> dotnet ef database update --project [nombreSolucion]
*/
