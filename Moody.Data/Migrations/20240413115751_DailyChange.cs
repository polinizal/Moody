using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moody.Data.Migrations
{
    /// <inheritdoc />
    public partial class DailyChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dailies_Moods_MoodId",
                table: "Dailies");

            migrationBuilder.DropIndex(
                name: "IX_Dailies_MoodId",
                table: "Dailies");

            migrationBuilder.RenameColumn(
                name: "MoodId",
                table: "Dailies",
                newName: "Mood");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mood",
                table: "Dailies",
                newName: "MoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Dailies_MoodId",
                table: "Dailies",
                column: "MoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dailies_Moods_MoodId",
                table: "Dailies",
                column: "MoodId",
                principalTable: "Moods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
