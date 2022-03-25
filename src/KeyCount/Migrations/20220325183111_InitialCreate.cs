using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KeyCount.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayKeyCount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Day = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayKeyCount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeyList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KeyCode = table.Column<int>(type: "INTEGER", nullable: false),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayKeyCount_Day",
                table: "DayKeyCount",
                column: "Day",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KeyList_KeyCode",
                table: "KeyList",
                column: "KeyCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayKeyCount");

            migrationBuilder.DropTable(
                name: "KeyList");
        }
    }
}
