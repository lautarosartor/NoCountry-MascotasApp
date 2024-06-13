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
                name: "Localidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IdProvincia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidad_Provincia_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "Provincia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Provincia",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Buenos Aires" },
                    { 2, "Catamarca" },
                    { 3, "Chaco" },
                    { 4, "Chubut" },
                    { 5, "Ciudad Autónoma de Buenos Aires" },
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
                    { 23, "Tierra del Fuego, Antártida e Islas del Atlántico Sur" },
                    { 24, "Tucumán" }
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
                table: "Localidad",
                columns: new[] { "Id", "IdProvincia", "Nombre" },
                values: new object[,]
                {
                    { 1, 21, "Avellaneda" },
                    { 2, 21, "Reconquista" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Borrado", "Descripcion", "Direccion", "Email", "IdLocalidad", "IdProvincia", "IdRol", "Nombre", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "SRL", false, "", "", "refugio@g.com", 1, 21, 2, "Refugio", new byte[] { 27, 148, 193, 181, 10, 96, 126, 125, 135, 205, 255, 15, 16, 231, 128, 172, 23, 205, 208, 219, 135, 189, 51, 167, 70, 226, 219, 82, 191, 97, 10, 243, 248, 110, 221, 100, 30, 6, 64, 8, 77, 1, 17, 234, 228, 243, 147, 231, 177, 206, 152, 72, 126, 133, 224, 26, 91, 23, 234, 161, 217, 39, 73, 26 }, new byte[] { 103, 71, 199, 174, 182, 25, 63, 196, 158, 37, 83, 212, 116, 131, 88, 29, 208, 217, 196, 81, 202, 95, 107, 202, 111, 148, 243, 241, 143, 157, 173, 37, 233, 234, 6, 24, 248, 32, 226, 198, 225, 206, 60, 145, 116, 72, 90, 134, 198, 12, 2, 143, 83, 156, 124, 219, 1, 104, 202, 59, 107, 108, 251, 74, 184, 71, 47, 176, 94, 108, 88, 170, 1, 51, 129, 131, 12, 156, 164, 22, 0, 132, 230, 33, 161, 223, 189, 196, 203, 204, 7, 217, 65, 159, 248, 9, 29, 246, 189, 122, 113, 209, 51, 50, 148, 242, 119, 161, 69, 29, 144, 35, 207, 41, 13, 127, 55, 100, 239, 64, 169, 247, 138, 139, 127, 159, 33, 61 } });

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
                name: "IX_Localidad_IdProvincia",
                table: "Localidad",
                column: "IdProvincia");

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
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Provincia");
        }
    }
}
