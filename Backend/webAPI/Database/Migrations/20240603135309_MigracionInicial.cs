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
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
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
                    Meses = table.Column<int>(type: "INTEGER", nullable: false),
                    Años = table.Column<int>(type: "INTEGER", nullable: false),
                    Especie = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Raza = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UrlImagen = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
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
                    { 1, "Buenos Aires" },
                    { 2, "Ciudad Autónoma de Buenos Aires" },
                    { 3, "Catamarca" },
                    { 4, "Chaco" },
                    { 5, "Chubut" },
                    { 6, "Córdoba" },
                    { 7, "Corrientes" },
                    { 8, "Entre Ríos" },
                    { 9, "Formosa" },
                    { 10, "Jujuy" },
                    { 11, "La Pampa" },
                    { 12, "La Rioja" },
                    { 13, "Mendoza" },
                    { 14, "Misiones" },
                    { 15, "Neuquén" },
                    { 16, "Río Negro" },
                    { 17, "Salta" },
                    { 18, "San Juan" },
                    { 19, "San Luis" },
                    { 20, "Santa Cruz" },
                    { 21, "Santa Fe" },
                    { 22, "Santiago del Estero" },
                    { 23, "Tierra del Fuego" }
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
                columns: new[] { "Id", "Apellido", "Borrado", "Descripcion", "Direccion", "Email", "IdLocalidad", "IdProvincia", "IdRol", "Nombre", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "SRL", false, "", "", "refugio@g.com", 1, 21, 2, "Refugio", new byte[] { 200, 65, 251, 184, 55, 177, 67, 156, 203, 72, 252, 152, 132, 121, 104, 85, 230, 164, 16, 65, 58, 53, 45, 40, 161, 225, 152, 26, 109, 98, 171, 25, 51, 143, 231, 79, 179, 49, 15, 61, 233, 147, 0, 46, 150, 41, 101, 132, 85, 20, 205, 196, 168, 71, 182, 24, 20, 203, 252, 50, 185, 13, 220, 163 }, new byte[] { 254, 226, 158, 134, 41, 147, 94, 240, 233, 37, 180, 139, 62, 203, 37, 59, 72, 137, 203, 215, 208, 87, 125, 205, 101, 208, 224, 234, 201, 198, 104, 184, 229, 235, 85, 171, 44, 92, 182, 219, 140, 144, 177, 48, 102, 109, 143, 93, 54, 42, 50, 58, 158, 19, 116, 32, 94, 12, 189, 53, 230, 57, 149, 142, 55, 110, 182, 144, 191, 78, 72, 13, 198, 45, 19, 21, 169, 162, 222, 185, 106, 83, 193, 50, 67, 135, 187, 5, 224, 102, 99, 14, 172, 72, 6, 216, 32, 10, 53, 21, 7, 140, 229, 70, 75, 31, 18, 219, 72, 93, 200, 13, 98, 18, 161, 3, 55, 11, 8, 238, 68, 237, 28, 146, 113, 30, 137, 156 } });

            migrationBuilder.InsertData(
                table: "Mascota",
                columns: new[] { "Id", "Años", "Borrado", "Descripcion", "Especie", "Estado", "IdUsuario", "Meses", "Nombre", "Raza", "UrlImagen" },
                values: new object[,]
                {
                    { 1, 1, false, "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere eum animi saepe odio accusantium.", "Gato", "Disponible", 1, 3, "Michi", "Gris", "https://w.wallhaven.cc/full/p9/wallhaven-p9gr59.jpg" },
                    { 2, 2, false, "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere eum animi saepe odio accusantium.", "Gato", "Disponible", 1, 1, "Michifus", "Marmolado", "https://w.wallhaven.cc/full/lq/wallhaven-lqm2zl.jpg" },
                    { 3, 1, false, "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere eum animi saepe odio accusantium.", "Perro", "Disponible", 1, 1, "Firu", "Aleman", "https://w.wallhaven.cc/full/4x/wallhaven-4xjqel.jpg" },
                    { 4, 2, false, "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere eum animi saepe odio accusantium.", "Perro", "Disponible", 1, 2, "Firulais", "Callejero", "https://w.wallhaven.cc/full/p9/wallhaven-p9gr59.jpg" }
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
