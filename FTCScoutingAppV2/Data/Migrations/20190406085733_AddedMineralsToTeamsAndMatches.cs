using Microsoft.EntityFrameworkCore.Migrations;

namespace FTCScoutingAppV2.Data.Migrations
{
    public partial class AddedMineralsToTeamsAndMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "cycles",
                table: "Team",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "depotMinerals",
                table: "Team",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "goldMinerals",
                table: "Team",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "silverMinerals",
                table: "Team",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "cycles",
                table: "Match",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "depotMinerals",
                table: "Match",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "goldMinerals",
                table: "Match",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "silverMinerals",
                table: "Match",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cycles",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "depotMinerals",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "goldMinerals",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "silverMinerals",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "cycles",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "depotMinerals",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "goldMinerals",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "silverMinerals",
                table: "Match");
        }
    }
}
