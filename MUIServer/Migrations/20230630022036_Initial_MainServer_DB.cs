using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MUIServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial_MainServer_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainServer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainServerID = table.Column<int>(type: "int", nullable: false),
                    MainServerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainServerVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainServerIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainServerPort = table.Column<int>(type: "int", nullable: true),
                    MainServerURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainServerTimeStart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainServerTimeEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainServerLivetime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainServer", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainServer");
        }
    }
}
