using Microsoft.EntityFrameworkCore.Migrations;

namespace FTCScoutingAppV2.Data.Migrations
{
    public partial class AddedNumberToMatches : Migration
    {
        #region Protected Methods

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "matchNumber",
                table: "MatchList");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "matchNumber",
                table: "MatchList",
                nullable: true);
        }

        #endregion Protected Methods
    }
}