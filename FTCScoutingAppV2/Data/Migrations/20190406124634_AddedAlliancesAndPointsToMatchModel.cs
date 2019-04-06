using Microsoft.EntityFrameworkCore.Migrations;

namespace FTCScoutingAppV2.Data.Migrations
{
    public partial class AddedAlliancesAndPointsToMatchModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "allance",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "points",
                table: "Match",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "allance",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "points",
                table: "Match");
        }
    }
}
