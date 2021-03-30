using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupAssignment.Migrations
{
    public partial class PerAssignmentInstructions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Organizer_OrganizerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMyUser_AspNetUsers_MyUserId",
                table: "EventMyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMyUser_Event_EventsId",
                table: "EventMyUser");

            migrationBuilder.DropTable(
                name: "Organizer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventMyUser",
                table: "EventMyUser");

            migrationBuilder.DropIndex(
                name: "IX_EventMyUser_MyUserId",
                table: "EventMyUser");

            migrationBuilder.RenameColumn(
                name: "MyUserId",
                table: "EventMyUser",
                newName: "AttendeesId");

            migrationBuilder.RenameColumn(
                name: "EventsId",
                table: "EventMyUser",
                newName: "JoinedEventsId");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "Event",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventMyUser",
                table: "EventMyUser",
                columns: new[] { "AttendeesId", "JoinedEventsId" });

            migrationBuilder.CreateIndex(
                name: "IX_EventMyUser_JoinedEventsId",
                table: "EventMyUser",
                column: "JoinedEventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_AspNetUsers_OrganizerId",
                table: "Event",
                column: "OrganizerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventMyUser_AspNetUsers_AttendeesId",
                table: "EventMyUser",
                column: "AttendeesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventMyUser_Event_JoinedEventsId",
                table: "EventMyUser",
                column: "JoinedEventsId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_AspNetUsers_OrganizerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMyUser_AspNetUsers_AttendeesId",
                table: "EventMyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMyUser_Event_JoinedEventsId",
                table: "EventMyUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventMyUser",
                table: "EventMyUser");

            migrationBuilder.DropIndex(
                name: "IX_EventMyUser_JoinedEventsId",
                table: "EventMyUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "JoinedEventsId",
                table: "EventMyUser",
                newName: "EventsId");

            migrationBuilder.RenameColumn(
                name: "AttendeesId",
                table: "EventMyUser",
                newName: "MyUserId");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizerId",
                table: "Event",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventMyUser",
                table: "EventMyUser",
                columns: new[] { "EventsId", "MyUserId" });

            migrationBuilder.CreateTable(
                name: "Organizer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventMyUser_MyUserId",
                table: "EventMyUser",
                column: "MyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Organizer_OrganizerId",
                table: "Event",
                column: "OrganizerId",
                principalTable: "Organizer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventMyUser_AspNetUsers_MyUserId",
                table: "EventMyUser",
                column: "MyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventMyUser_Event_EventsId",
                table: "EventMyUser",
                column: "EventsId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
