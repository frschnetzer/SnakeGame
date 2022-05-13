using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnakeGame.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SnakeGameDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Highscore = table.Column<int>(type: "int", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnakeGameDb", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SnakeGameDb");
        }
    }
}
