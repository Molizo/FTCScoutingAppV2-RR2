using Microsoft.EntityFrameworkCore.Migrations;

namespace FTCScoutingAppV2.Data.Migrations
{
    public partial class FixedTypoInMatchModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "allance",
                table: "Match");

            migrationBuilder.AddColumn<int>(
                name: "alliance",
                table: "Match",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alliance",
                table: "Match");

            migrationBuilder.AddColumn<int>(
                name: "allance",
                table: "Match",
                nullable: true);
        }
    }
}
