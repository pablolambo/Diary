using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BadgesAndThemes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationEntity");

            migrationBuilder.AddColumn<int>(
                name: "Statistics_Points",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    DiaryUserEntityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Badges_AspNetUsers_DiaryUserEntityId",
                        column: x => x.DiaryUserEntityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimaryColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    DiaryUserEntityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Themes_AspNetUsers_DiaryUserEntityId",
                        column: x => x.DiaryUserEntityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("3099c70c-5e94-4218-8a3a-7b9e906f3c93"), null, "10 total entries", 1, 10 },
                    { new Guid("63d60bc1-aa74-410b-a313-e0dc6e967a6d"), null, "50 total entries", 1, 50 },
                    { new Guid("9e31b7d7-b1ab-4600-b326-4ef682e32c1c"), null, "3 day streak", 0, 3 },
                    { new Guid("abbe3e8f-47cd-4b92-9391-62e220b35ee7"), null, "25 total entries", 1, 25 },
                    { new Guid("ed2bb551-b943-4c37-b144-6d1573905ed6"), null, "5 day streak", 0, 5 },
                    { new Guid("fd7f2140-458b-4d40-be00-27a6c0d821f7"), null, "7 day streak", 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Cost", "DiaryUserEntityId", "PrimaryColor", "SecondaryColor" },
                values: new object[,]
                {
                    { new Guid("05cc408f-dca7-49ae-8cce-d5f7ee3ceac8"), 250, null, "Red", "DarkRed" },
                    { new Guid("ead45be1-f561-4d0d-9ffc-551dfe46b253"), 100, null, "Blue", "LightBlue" },
                    { new Guid("f092c256-4bfb-4af7-81f2-42c3b428382b"), 500, null, "Green", "DarkGreen" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badges_DiaryUserEntityId",
                table: "Badges",
                column: "DiaryUserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_DiaryUserEntityId",
                table: "Themes",
                column: "DiaryUserEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropColumn(
                name: "Statistics_Points",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "NotificationEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiaryUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SentTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationEntity_AspNetUsers_DiaryUserId",
                        column: x => x.DiaryUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationEntity_DiaryUserId",
                table: "NotificationEntity",
                column: "DiaryUserId");
        }
    }
}
