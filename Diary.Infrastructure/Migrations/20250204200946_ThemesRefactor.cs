using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThemesRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("0384ee5c-9d76-4fa9-b84f-381da7889a23"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("4294f539-22ed-4e6d-9609-edfaed587a04"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("5f6862ac-9a17-488e-8513-1074ce3d2c0d"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("76ab3fb7-e6dc-490f-9139-9028b3e234d9"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("d1de5b43-f45c-4f65-a096-8442b977e751"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("d3b6c14a-3ce4-42f7-bad8-206328767406"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("fd17e06f-6050-4b81-96b3-9ff43bf2a795"));

            migrationBuilder.CreateTable(
                name: "UserTheme",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimaryColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    IsBought = table.Column<bool>(type: "bit", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    DiaryUserEntityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTheme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTheme_AspNetUsers_DiaryUserEntityId",
                        column: x => x.DiaryUserEntityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("05f1086a-9b94-4e4d-9ef6-c0d039139029"), null, "5 day streak", 0, 5 },
                    { new Guid("1342e70c-031b-4c76-8ca8-98ecca50fcab"), null, "Your first entry", 1, 1 },
                    { new Guid("2beb66a6-74b7-45d2-9c2e-0f7dec5231b9"), null, "7 day streak", 0, 7 },
                    { new Guid("4799e760-7475-4e7f-b8ff-1b32bc1f03e4"), null, "50 total entries", 1, 50 },
                    { new Guid("5fcc9319-ec4e-4e97-b242-ec3680a8e1e3"), null, "25 total entries", 1, 25 },
                    { new Guid("d10f015d-7fb9-4b25-93a7-724b390e6fe5"), null, "10 total entries", 1, 10 },
                    { new Guid("d3446d62-ab04-4d3c-89fb-7966d460e907"), null, "3 day streak", 0, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTheme_DiaryUserEntityId",
                table: "UserTheme",
                column: "DiaryUserEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTheme");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("05f1086a-9b94-4e4d-9ef6-c0d039139029"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("1342e70c-031b-4c76-8ca8-98ecca50fcab"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("2beb66a6-74b7-45d2-9c2e-0f7dec5231b9"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("4799e760-7475-4e7f-b8ff-1b32bc1f03e4"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("5fcc9319-ec4e-4e97-b242-ec3680a8e1e3"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("d10f015d-7fb9-4b25-93a7-724b390e6fe5"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("d3446d62-ab04-4d3c-89fb-7966d460e907"));

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    DiaryUserEntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsBought = table.Column<bool>(type: "bit", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    PrimaryColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { new Guid("0384ee5c-9d76-4fa9-b84f-381da7889a23"), null, "5 day streak", 0, 5 },
                    { new Guid("4294f539-22ed-4e6d-9609-edfaed587a04"), null, "10 total entries", 1, 10 },
                    { new Guid("5f6862ac-9a17-488e-8513-1074ce3d2c0d"), null, "Your first entry", 1, 1 },
                    { new Guid("76ab3fb7-e6dc-490f-9139-9028b3e234d9"), null, "25 total entries", 1, 25 },
                    { new Guid("d1de5b43-f45c-4f65-a096-8442b977e751"), null, "3 day streak", 0, 3 },
                    { new Guid("d3b6c14a-3ce4-42f7-bad8-206328767406"), null, "7 day streak", 0, 7 },
                    { new Guid("fd17e06f-6050-4b81-96b3-9ff43bf2a795"), null, "50 total entries", 1, 50 }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Cost", "DiaryUserEntityId", "IsBought", "IsSelected", "PrimaryColor", "SecondaryColor" },
                values: new object[,]
                {
                    { new Guid("0eab4d32-c026-40d7-8ad1-c6e42ba0dbf2"), 500, null, false, false, "Green", "DarkGreen" },
                    { new Guid("35b5c319-b65f-46ac-9b74-bf78103dad79"), 100, null, false, false, "Blue", "LightBlue" },
                    { new Guid("e378f4dd-cf18-489e-937d-a81c40d8836b"), 250, null, false, false, "Red", "DarkRed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Themes_DiaryUserEntityId",
                table: "Themes",
                column: "DiaryUserEntityId");
        }
    }
}
