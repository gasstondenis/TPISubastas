using Microsoft.EntityFrameworkCore.Migrations;

namespace TPISubastas.Sitio.Migrations
{
    public partial class Subastas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Notificado",
                table: "SubastaProducto",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notificado",
                table: "SubastaProducto");
        }
    }
}
