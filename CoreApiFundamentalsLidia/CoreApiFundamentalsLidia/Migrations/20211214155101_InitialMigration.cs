using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreApiFundamentalsLidia.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Moniker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camps", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Camps",
                columns: new[] { "Id", "EventDate", "Length", "Moniker", "Name" },
                values: new object[] { 1, new DateTime(2018, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ATL2018", "Atlanta Code Camp" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Camps");
        }
    }
}
