﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webAPI.Database;

#nullable disable

namespace webAPI.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240527222115_MigracionInicial")]
    partial class MigracionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("webAPI.Models.Localidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Localidad");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Avellaneda"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Río Cuarto"
                        });
                });

            modelBuilder.Entity("webAPI.Models.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Años")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Borrado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Meses")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Raza")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImagen")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Mascota");
                });

            modelBuilder.Entity("webAPI.Models.Provincia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Provincia");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Buenos Aires"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Ciudad Autónoma de Buenos Aires"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Catamarca"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Chaco"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Chubut"
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Córdoba"
                        },
                        new
                        {
                            Id = 7,
                            Nombre = "Corrientes"
                        },
                        new
                        {
                            Id = 8,
                            Nombre = "Entre Ríos"
                        },
                        new
                        {
                            Id = 9,
                            Nombre = "Formosa"
                        },
                        new
                        {
                            Id = 10,
                            Nombre = "Jujuy"
                        },
                        new
                        {
                            Id = 11,
                            Nombre = "La Pampa"
                        },
                        new
                        {
                            Id = 12,
                            Nombre = "La Rioja"
                        },
                        new
                        {
                            Id = 13,
                            Nombre = "Mendoza"
                        },
                        new
                        {
                            Id = 14,
                            Nombre = "Misiones"
                        },
                        new
                        {
                            Id = 15,
                            Nombre = "Neuquén"
                        },
                        new
                        {
                            Id = 16,
                            Nombre = "Río Negro"
                        },
                        new
                        {
                            Id = 17,
                            Nombre = "Salta"
                        },
                        new
                        {
                            Id = 18,
                            Nombre = "San Juan"
                        },
                        new
                        {
                            Id = 19,
                            Nombre = "San Luis"
                        },
                        new
                        {
                            Id = 20,
                            Nombre = "Santa Cruz"
                        },
                        new
                        {
                            Id = 21,
                            Nombre = "Santa Fe"
                        },
                        new
                        {
                            Id = 22,
                            Nombre = "Santiago del Estero"
                        },
                        new
                        {
                            Id = 23,
                            Nombre = "Tierra del Fuego"
                        });
                });

            modelBuilder.Entity("webAPI.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rol");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Refugio"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Cliente"
                        });
                });

            modelBuilder.Entity("webAPI.Models.Solicitud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdMascota")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdMascota");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Solicitud");
                });

            modelBuilder.Entity("webAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Borrado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdLocalidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProvincia")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdRol")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("IdLocalidad");

                    b.HasIndex("IdProvincia");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("webAPI.Models.Mascota", b =>
                {
                    b.HasOne("webAPI.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("webAPI.Models.Solicitud", b =>
                {
                    b.HasOne("webAPI.Models.Mascota", "Mascota")
                        .WithMany()
                        .HasForeignKey("IdMascota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webAPI.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("webAPI.Models.Usuario", b =>
                {
                    b.HasOne("webAPI.Models.Localidad", "Localidad")
                        .WithMany()
                        .HasForeignKey("IdLocalidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webAPI.Models.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("IdProvincia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webAPI.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Localidad");

                    b.Navigation("Provincia");

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}
