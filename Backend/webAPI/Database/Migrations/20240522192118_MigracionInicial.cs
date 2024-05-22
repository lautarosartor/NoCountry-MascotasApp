using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webAPI.Database.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    IdRol = table.Column<int>(type: "INTEGER", nullable: false),
                    IdProvincia = table.Column<int>(type: "INTEGER", nullable: false),
                    IdLocalidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Borrado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Localidad_IdLocalidad",
                        column: x => x.IdLocalidad,
                        principalTable: "Localidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Provincia_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "Provincia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Edad = table.Column<int>(type: "INTEGER", nullable: false),
                    Especie = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Raza = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Borrado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascota_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMascota = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitud_Mascota_IdMascota",
                        column: x => x.IdMascota,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitud_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Localidad",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Avellaneda" },
                    { 2, "Río Cuarto" }
                });

            migrationBuilder.InsertData(
                table: "Provincia",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Santa Fe" },
                    { 2, "Córdoba" }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Refugio" },
                    { 3, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Borrado", "Descripcion", "Email", "IdLocalidad", "IdProvincia", "IdRol", "Nombre" },
                values: new object[,]
                {
                    { 1, "Sartor", false, "Probando", "lauty123@gmail.com", 1, 1, 1, "Lautaro" },
                    { 2, "Diaz", false, "Probando", "gonza123@gmail.com", 2, 2, 2, "Gonzalo" }
                });

            migrationBuilder.InsertData(
                table: "Mascota",
                columns: new[] { "Id", "Borrado", "Descripcion", "Edad", "Especie", "Estado", "IdUsuario", "Nombre", "Raza" },
                values: new object[,]
                {
                    { 1, false, "Probandooo", 2, "Perro", "Disponible", 1, "Firulais", "Labrador" },
                    { 2, false, "Probandooo", 5, "Gato", "Disponible", 2, "Michi", "Siamez" }
                });

            migrationBuilder.InsertData(
                table: "Solicitud",
                columns: new[] { "Id", "Estado", "Fecha", "IdMascota", "IdUsuario" },
                values: new object[,]
                {
                    { 1, "Solicitado", new DateTime(2024, 5, 22, 16, 21, 17, 574, DateTimeKind.Local).AddTicks(2695), 1, 1 },
                    { 2, "Solicitado", new DateTime(2024, 5, 22, 16, 21, 17, 574, DateTimeKind.Local).AddTicks(2708), 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdUsuario",
                table: "Mascota",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_IdMascota",
                table: "Solicitud",
                column: "IdMascota");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_IdUsuario",
                table: "Solicitud",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdLocalidad",
                table: "Usuario",
                column: "IdLocalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdProvincia",
                table: "Usuario",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRol",
                table: "Usuario",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Localidad");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
