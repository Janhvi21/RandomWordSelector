using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomWord.Migrations
{
    public partial class AddTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeRemaining",
                table: "commandLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeRemaining",
                table: "commandLogs");
        }
    }
}
