using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThemesRefactor4 : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserThemes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserThemes",
                table: "UserThemes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("52dd99c0-6a44-4996-aa07-23a7499ba33e"), null, "7 day streak", 0, 7 },
                    { new Guid("543f0c3c-c7eb-45bd-b603-0904b4e5ed0f"), null, "Your first entry", 1, 1 },
                    { new Guid("9e8a6b3c-5414-462c-9a57-3517fd6917af"), null, "10 total entries", 1, 10 },
                    { new Guid("b858c2a4-9389-4071-bc05-129141d8e97a"), null, "25 total entries", 1, 25 },
                    { new Guid("cbec5904-1a92-48a5-a00a-7f5aea0ba299"), null, "3 day streak", 0, 3 },
                    { new Guid("de35830d-d98a-42aa-b955-8c20644229c5"), null, "50 total entries", 1, 50 },
                    { new Guid("f107b982-878c-42cc-96b5-932d14c252b7"), null, "5 day streak", 0, 5 }
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
                keyValue: new Guid("52dd99c0-6a44-4996-aa07-23a7499ba33e"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("543f0c3c-c7eb-45bd-b603-0904b4e5ed0f"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("9e8a6b3c-5414-462c-9a57-3517fd6917af"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("b858c2a4-9389-4071-bc05-129141d8e97a"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("cbec5904-1a92-48a5-a00a-7f5aea0ba299"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("de35830d-d98a-42aa-b955-8c20644229c5"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("f107b982-878c-42cc-96b5-932d14c252b7"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserThemes");

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
    }
}
