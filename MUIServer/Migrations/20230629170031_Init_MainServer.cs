using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MUIServer.Migrations
{
    /// <inheritdoc />
    public partial class Init_MainServer : Migration
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
                    MainServerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MainServerVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainServerIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainServerPort = table.Column<int>(type: "int", nullable: false),
                    MainServerURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainServerTimeStart = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MainServerTimeEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainServerLifetime = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
