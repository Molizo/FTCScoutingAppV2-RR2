using Microsoft.EntityFrameworkCore.Migrations;

namespace FTCScoutingAppV2.Data.Migrations
{
    public partial class AddedEventIDToMatchList : Migration
    {
        #region Protected Methods

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eventID",
                table: "MatchList");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "eventID",
                table: "MatchList",
                nullable: true);
        }

        #endregion Protected Methods
    }
}