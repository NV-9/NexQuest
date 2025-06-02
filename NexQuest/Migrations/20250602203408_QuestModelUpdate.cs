using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexQuest.Migrations
{
    /// <inheritdoc />
    public partial class QuestModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quest_Quest_ParentID",
                table: "Quest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quest",
                table: "Quest");

            migrationBuilder.RenameTable(
                name: "Quest",
                newName: "Quests");

            migrationBuilder.RenameIndex(
                name: "IX_Quest_ParentID",
                table: "Quests",
                newName: "IX_Quests_ParentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quests",
                table: "Quests",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Quests_ParentID",
                table: "Quests",
                column: "ParentID",
                principalTable: "Quests",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Quests_ParentID",
                table: "Quests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quests",
                table: "Quests");

            migrationBuilder.RenameTable(
                name: "Quests",
                newName: "Quest");

            migrationBuilder.RenameIndex(
                name: "IX_Quests_ParentID",
                table: "Quest",
                newName: "IX_Quest_ParentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quest",
                table: "Quest",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quest_Quest_ParentID",
                table: "Quest",
                column: "ParentID",
                principalTable: "Quest",
                principalColumn: "ID");
        }
    }
}
