using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserBadgesRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_AspNetUsers_DiaryUserEntityId",
                table: "Badges");

            migrationBuilder.DropIndex(
                name: "IX_Badges_DiaryUserEntityId",
                table: "Badges");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("11383a9b-d0ca-4b1f-abee-fdecf0a49f8a"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("5ba1b8ff-2d18-4eb5-af37-7bf238d04d23"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("5e0adf75-4310-4dcd-99ef-b5257ccac7e1"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("a5f77bf0-284e-4660-9b94-d59487316544"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("d05c28cc-bcfd-462a-9256-5cad58747b10"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("f25f69d4-2bc3-4ba9-914f-4b466f9ec56a"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("fed5383d-b9dd-4fc8-a4bb-b4158471c04e"));

            migrationBuilder.DropColumn(
                name: "DiaryUserEntityId",
                table: "Badges");

            migrationBuilder.CreateTable(
                name: "UserBadgeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BadgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateEarned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBadgeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBadgeEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBadgeEntity_Badges_BadgeId",
                        column: x => x.BadgeId,
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("1d846e08-eab0-4b52-871a-32f4a635120b"), "Your first entry", 1, 1 },
                    { new Guid("46d340c6-9687-40a6-a730-a0eb6419f85d"), "7 day streak", 0, 7 },
                    { new Guid("532c74f7-7495-4899-a760-f5fd69b1cb67"), "5 day streak", 0, 5 },
                    { new Guid("71cbcfa2-40fd-40ff-ab78-f3099a05e811"), "50 total entries", 1, 50 },
                    { new Guid("7a96b7e5-c34d-4a2a-8269-061a78f1a0fe"), "10 total entries", 1, 10 },
                    { new Guid("afa0a380-4e9b-4a44-bcbe-f98567970cbc"), "3 day streak", 0, 3 },
                    { new Guid("d6035280-a8d0-4383-ace5-61cb9042e2c3"), "25 total entries", 1, 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBadgeEntity_BadgeId",
                table: "UserBadgeEntity",
                column: "BadgeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBadgeEntity_UserId_BadgeId",
                table: "UserBadgeEntity",
                columns: new[] { "UserId", "BadgeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBadgeEntity");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("1d846e08-eab0-4b52-871a-32f4a635120b"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("46d340c6-9687-40a6-a730-a0eb6419f85d"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("532c74f7-7495-4899-a760-f5fd69b1cb67"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("71cbcfa2-40fd-40ff-ab78-f3099a05e811"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("7a96b7e5-c34d-4a2a-8269-061a78f1a0fe"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("afa0a380-4e9b-4a44-bcbe-f98567970cbc"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("d6035280-a8d0-4383-ace5-61cb9042e2c3"));

            migrationBuilder.AddColumn<string>(
                name: "DiaryUserEntityId",
                table: "Badges",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("11383a9b-d0ca-4b1f-abee-fdecf0a49f8a"), null, "7 day streak", 0, 7 },
                    { new Guid("5ba1b8ff-2d18-4eb5-af37-7bf238d04d23"), null, "25 total entries", 1, 25 },
                    { new Guid("5e0adf75-4310-4dcd-99ef-b5257ccac7e1"), null, "50 total entries", 1, 50 },
                    { new Guid("a5f77bf0-284e-4660-9b94-d59487316544"), null, "10 total entries", 1, 10 },
                    { new Guid("d05c28cc-bcfd-462a-9256-5cad58747b10"), null, "3 day streak", 0, 3 },
                    { new Guid("f25f69d4-2bc3-4ba9-914f-4b466f9ec56a"), null, "5 day streak", 0, 5 },
                    { new Guid("fed5383d-b9dd-4fc8-a4bb-b4158471c04e"), null, "Your first entry", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badges_DiaryUserEntityId",
                table: "Badges",
                column: "DiaryUserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_AspNetUsers_DiaryUserEntityId",
                table: "Badges",
                column: "DiaryUserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
