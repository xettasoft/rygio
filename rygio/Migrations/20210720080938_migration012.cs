using Microsoft.EntityFrameworkCore.Migrations;

namespace rygio.Migrations
{
    public partial class migration012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceMembers_Experiences_ExperienceId",
                table: "ExperienceMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceMembers_Users_UserId",
                table: "ExperienceMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceStageCollectibles_ExperienceStages_ExperienceStageId",
                table: "ExperienceStageCollectibles");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceStages_Experiences_ExperienceId",
                table: "ExperienceStages");

            migrationBuilder.AlterColumn<int>(
                name: "ExperienceId",
                table: "ExperienceStages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExperienceStageId",
                table: "ExperienceStageCollectibles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CollectableId",
                table: "ExperienceStageCollectibles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Experiences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Universal",
                table: "Experiences",
                type: "nvarchar(64)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ExperienceMembers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExperienceId",
                table: "ExperienceMembers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceMembers_Experiences_ExperienceId",
                table: "ExperienceMembers",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceMembers_Users_UserId",
                table: "ExperienceMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceStageCollectibles_ExperienceStages_ExperienceStageId",
                table: "ExperienceStageCollectibles",
                column: "ExperienceStageId",
                principalTable: "ExperienceStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceStages_Experiences_ExperienceId",
                table: "ExperienceStages",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceMembers_Experiences_ExperienceId",
                table: "ExperienceMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceMembers_Users_UserId",
                table: "ExperienceMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceStageCollectibles_ExperienceStages_ExperienceStageId",
                table: "ExperienceStageCollectibles");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceStages_Experiences_ExperienceId",
                table: "ExperienceStages");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Universal",
                table: "Experiences");

            migrationBuilder.AlterColumn<int>(
                name: "ExperienceId",
                table: "ExperienceStages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExperienceStageId",
                table: "ExperienceStageCollectibles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CollectableId",
                table: "ExperienceStageCollectibles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ExperienceMembers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExperienceId",
                table: "ExperienceMembers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceMembers_Experiences_ExperienceId",
                table: "ExperienceMembers",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceMembers_Users_UserId",
                table: "ExperienceMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceStageCollectibles_ExperienceStages_ExperienceStageId",
                table: "ExperienceStageCollectibles",
                column: "ExperienceStageId",
                principalTable: "ExperienceStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceStages_Experiences_ExperienceId",
                table: "ExperienceStages",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
