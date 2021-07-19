using Microsoft.EntityFrameworkCore.Migrations;

namespace rygio.Migrations
{
    public partial class migration008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Radius",
                table: "Regions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Radius",
                table: "Regions");
        }
    }
}
