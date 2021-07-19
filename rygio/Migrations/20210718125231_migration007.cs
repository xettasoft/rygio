using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace rygio.Migrations
{
    public partial class migration007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Comments_CommentId",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Replies_CommentId",
                table: "Replies");

            migrationBuilder.AddColumn<Geometry>(
                name: "Border",
                table: "Regions",
                type: "geography",
                nullable: true);

            migrationBuilder.AddColumn<Point>(
                name: "Location",
                table: "Regions",
                type: "geometry",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Connection = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    PostAllowable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spheres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Connection = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    Location = table.Column<Point>(type: "geometry", nullable: true),
                    Border = table.Column<Geometry>(type: "geography", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spheres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomMembers_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomMembers_RoomId",
                table: "RoomMembers",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomMembers");

            migrationBuilder.DropTable(
                name: "Spheres");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropColumn(
                name: "Border",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Regions");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_CommentId",
                table: "Replies",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Comments_CommentId",
                table: "Replies",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
