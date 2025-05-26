using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexQuest.Migrations
{
    /// <inheritdoc />
    public partial class AddedQuestModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Quest_Quest_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Quest",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quest_ParentID",
                table: "Quest",
                column: "ParentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quest");
        }
    }
}
