using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TPISubastas.Sitio.Migrations
{
    public partial class SubastasDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoSubasta",
                columns: table => new
                {
                    IdEstadoSubasta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoSubasta", x => x.IdEstadoSubasta);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 256, nullable: false),
                    Marca = table.Column<string>(maxLength: 128, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 4096, nullable: false),
                    Imagen = table.Column<string>(maxLength: 1024, nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 256, nullable: false),
                    Apellido = table.Column<string>(maxLength: 256, nullable: false),
                    Documento = table.Column<string>(maxLength: 64, nullable: false),
                    Calle = table.Column<string>(maxLength: 1024, nullable: true),
                    Numero = table.Column<string>(maxLength: 64, nullable: true),
                    CodigoPostal = table.Column<string>(maxLength: 64, nullable: true),
                    Ciudad = table.Column<string>(maxLength: 1024, nullable: true),
                    Provincia = table.Column<string>(maxLength: 128, nullable: true),
                    Telefono = table.Column<string>(maxLength: 64, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Subasta",
                columns: table => new
                {
                    IdSubasta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: true),
                    FechaCierre = table.Column<DateTime>(nullable: true),
                    Duracion = table.Column<int>(nullable: false),
                    NombreProducto = table.Column<string>(maxLength: 256, nullable: false),
                    MarcaProducto = table.Column<string>(maxLength: 128, nullable: false),
                    DescripcionProducto = table.Column<string>(maxLength: 4096, nullable: false),
                    ImagenProducto = table.Column<string>(maxLength: 1024, nullable: false),
                    FormaPago = table.Column<string>(maxLength: 256, nullable: false),
                    MontoInicial = table.Column<decimal>(type: "Money", nullable: false),
                    IdEstadoSubasta = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    IdUsuarioComprador = table.Column<int>(nullable: true),
                    IdProducto = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subasta", x => x.IdSubasta);
                    table.ForeignKey(
                        name: "FK_Subasta_EstadoSubasta",
                        column: x => x.IdEstadoSubasta,
                        principalTable: "EstadoSubasta",
                        principalColumn: "IdEstadoSubasta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subasta_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subasta_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    IdOferta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSubasta = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.IdOferta);
                    table.ForeignKey(
                        name: "FK_Oferta_Subasta",
                        column: x => x.IdSubasta,
                        principalTable: "Subasta",
                        principalColumn: "IdSubasta");
                    table.ForeignKey(
                        name: "FK_Oferta_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_IdSubasta",
                table: "Oferta",
                column: "IdSubasta");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_IdUsuario",
                table: "Oferta",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Subasta_IdEstadoSubasta",
                table: "Subasta",
                column: "IdEstadoSubasta");

            migrationBuilder.CreateIndex(
                name: "IX_Subasta_IdProducto",
                table: "Subasta",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Subasta_IdUsuario",
                table: "Subasta",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Subasta");

            migrationBuilder.DropTable(
                name: "EstadoSubasta");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
