using Microsoft.EntityFrameworkCore.Migrations;

namespace FTCScoutingAppV2.Data.Migrations
{
    public partial class UpdatedModelsForRoverRuckus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvgPTS",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpPTS",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OPR",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "doubleSampling",
                table: "Team",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "endLocation",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "landing",
                table: "Team",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "parking",
                table: "Team",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sampling",
                table: "Team",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "startLocation",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "teamMarker",
                table: "Team",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "doubleSampling",
                table: "Match",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "endLocation",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "landing",
                table: "Match",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "parking",
                table: "Match",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sampling",
                table: "Match",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "startLocation",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "teamMarker",
                table: "Match",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgPTS",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ExpPTS",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "OPR",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "doubleSampling",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "endLocation",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "landing",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "parking",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "sampling",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "startLocation",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "teamMarker",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "doubleSampling",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "endLocation",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "landing",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "parking",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "sampling",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "startLocation",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "teamMarker",
                table: "Match");
        }
    }
}
