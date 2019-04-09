using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FTCScoutingAppV2.Data.Migrations
{
    public partial class Initial : Migration
    {
        #region Protected Methods

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Team");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eventName = table.Column<string>(nullable: true),
                    eventLocation = table.Column<string>(nullable: true),
                    allowedUserIDs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    matchType = table.Column<int>(nullable: true),
                    matchNumber = table.Column<string>(nullable: true),
                    alliance = table.Column<int>(nullable: true),
                    points = table.Column<decimal>(nullable: false),
                    startLocation = table.Column<int>(nullable: true),
                    landing = table.Column<bool>(nullable: false),
                    sampling = table.Column<bool>(nullable: false),
                    doubleSampling = table.Column<bool>(nullable: false),
                    teamMarker = table.Column<bool>(nullable: false),
                    parking = table.Column<bool>(nullable: false),
                    goldMinerals = table.Column<decimal>(nullable: false),
                    silverMinerals = table.Column<decimal>(nullable: false),
                    depotMinerals = table.Column<decimal>(nullable: false),
                    cycles = table.Column<decimal>(nullable: false),
                    endLocation = table.Column<int>(nullable: true),
                    teamID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    teamID = table.Column<string>(nullable: false),
                    teamName = table.Column<string>(nullable: false),
                    teamLocation = table.Column<string>(nullable: true),
                    ExpPTS = table.Column<decimal>(nullable: false),
                    AvgPTS = table.Column<decimal>(nullable: false),
                    OPR = table.Column<int>(nullable: false),
                    goldMinerals = table.Column<decimal>(nullable: false),
                    silverMinerals = table.Column<decimal>(nullable: false),
                    depotMinerals = table.Column<decimal>(nullable: false),
                    cycles = table.Column<decimal>(nullable: false),
                    startLocation = table.Column<int>(nullable: true),
                    landing = table.Column<bool>(nullable: false),
                    sampling = table.Column<bool>(nullable: false),
                    doubleSampling = table.Column<bool>(nullable: false),
                    teamMarker = table.Column<bool>(nullable: false),
                    parking = table.Column<bool>(nullable: false),
                    endLocation = table.Column<int>(nullable: true),
                    comments = table.Column<string>(nullable: true),
                    eventID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.ID);
                });
        }

        #endregion Protected Methods
    }
}