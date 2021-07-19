using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace rygio.Migrations
{
    public partial class migration009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropColumn(
                name: "CoordinateId",
                table: "ExperienceStages");

            migrationBuilder.AddColumn<Geometry>(
                name: "Border",
                table: "ExperienceStages",
                type: "geography",
                nullable: true);

            migrationBuilder.AddColumn<Point>(
                name: "Location",
                table: "ExperienceStages",
                type: "geometry",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "Border",
                table: "Experiences",
                type: "geography",
                nullable: true);

            migrationBuilder.AddColumn<Point>(
                name: "Location",
                table: "Experiences",
                type: "geometry",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Border",
                table: "ExperienceStages");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ExperienceStages");

            migrationBuilder.DropColumn(
                name: "Border",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Experiences");

            migrationBuilder.AddColumn<int>(
                name: "CoordinateId",
                table: "ExperienceStages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Border = table.Column<Geometry>(type: "geography", nullable: true),
                    CoordinateType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExperienceId = table.Column<int>(type: "int", nullable: true),
                    IsAction = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSearchable = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<Point>(type: "geometry", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });
        }
    }
}
