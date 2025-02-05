using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThemesRefactor2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTheme_AspNetUsers_DiaryUserEntityId",
                table: "UserTheme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTheme",
                table: "UserTheme");

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

            migrationBuilder.RenameTable(
                name: "UserTheme",
                newName: "UserThemes");

            migrationBuilder.RenameIndex(
                name: "IX_UserTheme_DiaryUserEntityId",
                table: "UserThemes",
                newName: "IX_UserThemes_DiaryUserEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserThemes",
                table: "UserThemes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("2f9c831f-741d-45af-9613-d794058c8250"), null, "3 day streak", 0, 3 },
                    { new Guid("3501eb90-3e1c-4459-a49b-595a6258bd5c"), null, "7 day streak", 0, 7 },
                    { new Guid("9533d7fa-84a3-42a7-b474-fc3ee3ce52df"), null, "25 total entries", 1, 25 },
                    { new Guid("b9b93a12-28d6-4849-9b46-bf61a8d55656"), null, "Your first entry", 1, 1 },
                    { new Guid("c7a48dd4-c48b-425c-b317-29f7ff27b4ed"), null, "50 total entries", 1, 50 },
                    { new Guid("e941818f-7f64-4007-887d-d19e63f32fa5"), null, "10 total entries", 1, 10 },
                    { new Guid("ed01e833-2853-4a17-8d42-c6bd855e9cd9"), null, "5 day streak", 0, 5 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserThemes_AspNetUsers_DiaryUserEntityId",
                table: "UserThemes",
                column: "DiaryUserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserThemes_AspNetUsers_DiaryUserEntityId",
                table: "UserThemes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserThemes",
                table: "UserThemes");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("2f9c831f-741d-45af-9613-d794058c8250"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("3501eb90-3e1c-4459-a49b-595a6258bd5c"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("9533d7fa-84a3-42a7-b474-fc3ee3ce52df"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("b9b93a12-28d6-4849-9b46-bf61a8d55656"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("c7a48dd4-c48b-425c-b317-29f7ff27b4ed"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("e941818f-7f64-4007-887d-d19e63f32fa5"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("ed01e833-2853-4a17-8d42-c6bd855e9cd9"));

            migrationBuilder.RenameTable(
                name: "UserThemes",
                newName: "UserTheme");

            migrationBuilder.RenameIndex(
                name: "IX_UserThemes_DiaryUserEntityId",
                table: "UserTheme",
                newName: "IX_UserTheme_DiaryUserEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTheme",
                table: "UserTheme",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserTheme_AspNetUsers_DiaryUserEntityId",
                table: "UserTheme",
                column: "DiaryUserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
