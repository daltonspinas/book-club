using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace book_club.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "BookClub",
                columns: table => new
                {
                    ClubID = table.Column<int>(type: "int", nullable: false),
                    ClubName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookClub", x => x.ClubID);
                    table.ForeignKey(
                        name: "FK_BookClub_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "BookClubMembers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ClubID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookClubMembers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookClubMembers_BookClub",
                        column: x => x.ClubID,
                        principalTable: "BookClub",
                        principalColumn: "ClubID");
                    table.ForeignKey(
                        name: "FK_BookClubMembers_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ClubMeeting",
                columns: table => new
                {
                    MeetingID = table.Column<int>(type: "int", nullable: false),
                    ClubID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    BookID = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    HostID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubMeeting", x => x.MeetingID);
                    table.ForeignKey(
                        name: "FK_ClubMeeting_BookClub",
                        column: x => x.ClubID,
                        principalTable: "BookClub",
                        principalColumn: "ClubID");
                    table.ForeignKey(
                        name: "FK_ClubMeeting_User",
                        column: x => x.HostID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "RSVP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    MeetingID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RSVPStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSVP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RSVP_ClubMeeting",
                        column: x => x.MeetingID,
                        principalTable: "ClubMeeting",
                        principalColumn: "MeetingID");
                    table.ForeignKey(
                        name: "FK_RSVP_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.InsertData(
                table: "BookClub",
                columns: new[] { "ClubID", "ClubName", "OwnerID", "UserId" },
                values: new object[] { 1, "Demo Book Club", 1, null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "test@gmail.com", "password", "Demo Owner 1" },
                    { 2, "test@gmail.com", "password", "Demo Member 1" },
                    { 3, "test@gmail.com", "password", "Demo Member 2" },
                    { 4, "test@gmail.com", "password", "Demo Member 3" }
                });

            migrationBuilder.InsertData(
                table: "BookClubMembers",
                columns: new[] { "ID", "ClubID", "UserID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "ClubMeeting",
                columns: new[] { "MeetingID", "BookID", "ClubID", "Date", "HostID", "Location" },
                values: new object[] { 1, null, 1, new DateTime(2023, 11, 2, 16, 31, 55, 203, DateTimeKind.Local).AddTicks(2277), 3, "1234 Address, City, State, Zip" });

            migrationBuilder.CreateIndex(
                name: "IX_BookClub",
                table: "BookClub",
                column: "OwnerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookClub_UserId",
                table: "BookClub",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookClubMembers_ClubID",
                table: "BookClubMembers",
                column: "ClubID");

            migrationBuilder.CreateIndex(
                name: "IX_BookClubMembers_UserID",
                table: "BookClubMembers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMeeting_ClubID",
                table: "ClubMeeting",
                column: "ClubID");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMeeting_HostID",
                table: "ClubMeeting",
                column: "HostID");

            migrationBuilder.CreateIndex(
                name: "IX_RSVP_MeetingID",
                table: "RSVP",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_RSVP_UserID",
                table: "RSVP",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookClubMembers");

            migrationBuilder.DropTable(
                name: "RSVP");

            migrationBuilder.DropTable(
                name: "ClubMeeting");

            migrationBuilder.DropTable(
                name: "BookClub");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
