using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moody.Data.Migrations
{
    /// <inheritdoc />
    public partial class DailyChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mood",
                table: "Dailies",
                newName: "MoodId");

            migrationBuilder.AlterColumn<string>(
                name: "MoodType",
                table: "Moods",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoodId",
                table: "Dailies",
                newName: "Mood");

            migrationBuilder.AlterColumn<int>(
                name: "MoodType",
                table: "Moods",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
