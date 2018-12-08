using Microsoft.EntityFrameworkCore.Migrations;

namespace BeltExam.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Users_UserId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendee_Activity_ActivityId",
                table: "Attendee");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendee_Users_UserId",
                table: "Attendee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendee",
                table: "Attendee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity",
                table: "Activity");

            migrationBuilder.RenameTable(
                name: "Attendee",
                newName: "Attendees");

            migrationBuilder.RenameTable(
                name: "Activity",
                newName: "Activities");

            migrationBuilder.RenameIndex(
                name: "IX_Attendee_UserId",
                table: "Attendees",
                newName: "IX_Attendees_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendee_ActivityId",
                table: "Attendees",
                newName: "IX_Attendees_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_UserId",
                table: "Activities",
                newName: "IX_Activities_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendees",
                table: "Attendees",
                column: "AttendeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Users_UserId",
                table: "Activities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Activities_ActivityId",
                table: "Attendees",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Users_UserId",
                table: "Attendees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Users_UserId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Activities_ActivityId",
                table: "Attendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Users_UserId",
                table: "Attendees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendees",
                table: "Attendees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "Attendees",
                newName: "Attendee");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "Activity");

            migrationBuilder.RenameIndex(
                name: "IX_Attendees_UserId",
                table: "Attendee",
                newName: "IX_Attendee_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendees_ActivityId",
                table: "Attendee",
                newName: "IX_Attendee_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_UserId",
                table: "Activity",
                newName: "IX_Activity_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendee",
                table: "Attendee",
                column: "AttendeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity",
                table: "Activity",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Users_UserId",
                table: "Activity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendee_Activity_ActivityId",
                table: "Attendee",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendee_Users_UserId",
                table: "Attendee",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
