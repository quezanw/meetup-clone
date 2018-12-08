using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeltExam.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Time",
                table: "Activities",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Time",
                table: "Activities",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
