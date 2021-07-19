using Microsoft.EntityFrameworkCore.Migrations;

namespace rygio.Migrations
{
    public partial class migration010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegionMembers_Regions_RegionId",
                table: "RegionMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_RegionMembers_Users_UserId",
                table: "RegionMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionMembers",
                table: "RegionMembers");

            migrationBuilder.RenameTable(
                name: "RegionMembers",
                newName: "RegionResidents");

            migrationBuilder.RenameIndex(
                name: "IX_RegionMembers_UserId",
                table: "RegionResidents",
                newName: "IX_RegionResidents_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RegionMembers_RegionId",
                table: "RegionResidents",
                newName: "IX_RegionResidents_RegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionResidents",
                table: "RegionResidents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegionResidents_Regions_RegionId",
                table: "RegionResidents",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegionResidents_Users_UserId",
                table: "RegionResidents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegionResidents_Regions_RegionId",
                table: "RegionResidents");

            migrationBuilder.DropForeignKey(
                name: "FK_RegionResidents_Users_UserId",
                table: "RegionResidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionResidents",
                table: "RegionResidents");

            migrationBuilder.RenameTable(
                name: "RegionResidents",
                newName: "RegionMembers");

            migrationBuilder.RenameIndex(
                name: "IX_RegionResidents_UserId",
                table: "RegionMembers",
                newName: "IX_RegionMembers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RegionResidents_RegionId",
                table: "RegionMembers",
                newName: "IX_RegionMembers_RegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionMembers",
                table: "RegionMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegionMembers_Regions_RegionId",
                table: "RegionMembers",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegionMembers_Users_UserId",
                table: "RegionMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
