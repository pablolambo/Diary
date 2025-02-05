using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThemesRefactor3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("46b7b0ec-0b12-485a-bc89-119f422b71fe"), null, "10 total entries", 1, 10 },
                    { new Guid("5414060d-9fe4-4c7a-b14d-9ac305986dca"), null, "3 day streak", 0, 3 },
                    { new Guid("8cf9bbc9-87ce-463f-801c-cba25df14bbb"), null, "25 total entries", 1, 25 },
                    { new Guid("a11fd9a9-704f-41b2-a637-d88763be6dde"), null, "50 total entries", 1, 50 },
                    { new Guid("b54d4a28-a762-4284-9069-5f5dedde1155"), null, "7 day streak", 0, 7 },
                    { new Guid("be49513b-87c1-4d00-9159-8e974266bc9c"), null, "5 day streak", 0, 5 },
                    { new Guid("fa756118-066d-4b08-991f-5deb025b192f"), null, "Your first entry", 1, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTheme_AspNetUsers_DiaryUserEntityId",
                table: "UserTheme",
                column: "DiaryUserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("46b7b0ec-0b12-485a-bc89-119f422b71fe"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("5414060d-9fe4-4c7a-b14d-9ac305986dca"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("8cf9bbc9-87ce-463f-801c-cba25df14bbb"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("a11fd9a9-704f-41b2-a637-d88763be6dde"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("b54d4a28-a762-4284-9069-5f5dedde1155"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("be49513b-87c1-4d00-9159-8e974266bc9c"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("fa756118-066d-4b08-991f-5deb025b192f"));

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
    }
}
