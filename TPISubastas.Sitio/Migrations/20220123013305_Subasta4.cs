using Microsoft.EntityFrameworkCore.Migrations;

namespace TPISubastas.Sitio.Migrations
{
    public partial class Subasta4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OfertaFinal",
                table: "SubastaProducto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfertaFinal",
                table: "SubastaProducto");
        }
    }
}
