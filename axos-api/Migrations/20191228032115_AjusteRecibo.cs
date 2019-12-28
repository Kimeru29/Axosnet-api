using Microsoft.EntityFrameworkCore.Migrations;

namespace axos_api.Migrations
{
    public partial class AjusteRecibo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Divisa",
                table: "Recibos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Divisa",
                table: "Recibos");
        }
    }
}
