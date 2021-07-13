using Microsoft.EntityFrameworkCore.Migrations;

namespace rygio.Migrations
{
    public partial class migration005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "RegionMembers");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "PostMembers");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Payouts");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "ExperienceStages");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "ExperienceStageCollectibles");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "ExperienceMembers");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "DebitCards");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Coordinates");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "CollectableTrails");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "BankAccounts");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_Reference",
                table: "Regions",
                column: "Reference",
                unique: true,
                filter: "[Reference] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Reference",
                table: "Posts",
                column: "Reference",
                unique: true,
                filter: "[Reference] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_Reference",
                table: "Experiences",
                column: "Reference",
                unique: true,
                filter: "[Reference] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Collectables_Reference",
                table: "Collectables",
                column: "Reference",
                unique: true,
                filter: "[Reference] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Regions_Reference",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Posts_Reference",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_Reference",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Collectables_Reference",
                table: "Collectables");

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Users",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Transactions",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Replies",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "RegionMembers",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "RefreshTokens",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "PostMembers",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Payouts",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "ExperienceStages",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "ExperienceStageCollectibles",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "ExperienceMembers",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "DebitCards",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Coordinates",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Comments",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "CollectableTrails",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "BankAccounts",
                type: "nvarchar(128)",
                nullable: true);
        }
    }
}
