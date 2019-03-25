using Microsoft.EntityFrameworkCore.Migrations;

namespace FTCScoutingAppV2.Data.Migrations
{
    public partial class UpdatedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "Team",
                newName: "eventID");

            migrationBuilder.RenameColumn(
                name: "TeamID",
                table: "Match",
                newName: "teamID");

            migrationBuilder.AlterColumn<string>(
                name: "eventID",
                table: "Team",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "teamID",
                table: "Match",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "eventID",
                table: "Team",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "teamID",
                table: "Match",
                newName: "TeamID");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Team",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Match",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_EventID",
                table: "Team",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TeamID",
                table: "Match",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_TeamID",
                table: "Match",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Event_EventID",
                table: "Team",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
