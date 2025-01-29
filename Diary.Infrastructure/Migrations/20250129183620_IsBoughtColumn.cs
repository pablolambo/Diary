using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsBoughtColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("2cf02038-f42e-45dd-b215-5482196ad84b"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("8755bd23-87f8-4e7c-bbf0-864671089008"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("99ccca80-53ee-4d6c-baae-6e3ada283761"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("b95a1705-6f1a-4dd3-a708-8d002d8f2621"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("cf268114-d173-4761-8fb2-1bb6ad860c97"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("d24c51b7-e323-4330-8577-0a7dd87d069e"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("db8391a8-a723-42d2-b7ac-b7a785fc57dd"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("03dd3d04-9bbb-42d4-81c5-5bb72ba55882"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("a41a15d8-0e6e-46dc-943c-3bce03c3f971"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("d44aed49-1933-4739-ad05-c41d97bf0b6d"));

            migrationBuilder.AddColumn<bool>(
                name: "IsBought",
                table: "Themes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("1c313e82-1b48-44bf-abac-e982152e372e"), null, "10 total entries", 1, 10 },
                    { new Guid("283692e5-5d61-4ce9-8a07-c64a5bfd2f93"), null, "25 total entries", 1, 25 },
                    { new Guid("60bb9c41-4165-4510-a1c1-3a0fd01cf01d"), null, "7 day streak", 0, 7 },
                    { new Guid("62653960-b00e-4aa0-8d5f-d6eb776f13ea"), null, "Your first entry", 1, 1 },
                    { new Guid("7b0a2cde-a5c7-4ff3-93f7-ecc29fbbdfb6"), null, "50 total entries", 1, 50 },
                    { new Guid("a0b0a0b1-fed7-493c-9445-ea52fcc99586"), null, "3 day streak", 0, 3 },
                    { new Guid("fad47918-6913-44b3-89f0-8dd8850e2519"), null, "5 day streak", 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Cost", "DiaryUserEntityId", "IsBought", "PrimaryColor", "SecondaryColor" },
                values: new object[,]
                {
                    { new Guid("2ebf24a1-b9bf-4332-b63c-260f557c5a81"), 100, null, false, "Blue", "LightBlue" },
                    { new Guid("5acc9785-412a-4664-8236-fb4517f1a6b2"), 250, null, false, "Red", "DarkRed" },
                    { new Guid("84e90460-276e-4db5-91ad-942aee59374c"), 500, null, false, "Green", "DarkGreen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("1c313e82-1b48-44bf-abac-e982152e372e"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("283692e5-5d61-4ce9-8a07-c64a5bfd2f93"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("60bb9c41-4165-4510-a1c1-3a0fd01cf01d"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("62653960-b00e-4aa0-8d5f-d6eb776f13ea"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("7b0a2cde-a5c7-4ff3-93f7-ecc29fbbdfb6"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("a0b0a0b1-fed7-493c-9445-ea52fcc99586"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("fad47918-6913-44b3-89f0-8dd8850e2519"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("2ebf24a1-b9bf-4332-b63c-260f557c5a81"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("5acc9785-412a-4664-8236-fb4517f1a6b2"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("84e90460-276e-4db5-91ad-942aee59374c"));

            migrationBuilder.DropColumn(
                name: "IsBought",
                table: "Themes");

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("2cf02038-f42e-45dd-b215-5482196ad84b"), null, "7 day streak", 0, 7 },
                    { new Guid("8755bd23-87f8-4e7c-bbf0-864671089008"), null, "3 day streak", 0, 3 },
                    { new Guid("99ccca80-53ee-4d6c-baae-6e3ada283761"), null, "50 total entries", 1, 50 },
                    { new Guid("b95a1705-6f1a-4dd3-a708-8d002d8f2621"), null, "10 total entries", 1, 10 },
                    { new Guid("cf268114-d173-4761-8fb2-1bb6ad860c97"), null, "Your first entry", 1, 1 },
                    { new Guid("d24c51b7-e323-4330-8577-0a7dd87d069e"), null, "25 total entries", 1, 25 },
                    { new Guid("db8391a8-a723-42d2-b7ac-b7a785fc57dd"), null, "5 day streak", 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Cost", "DiaryUserEntityId", "PrimaryColor", "SecondaryColor" },
                values: new object[,]
                {
                    { new Guid("03dd3d04-9bbb-42d4-81c5-5bb72ba55882"), 250, null, "Red", "DarkRed" },
                    { new Guid("a41a15d8-0e6e-46dc-943c-3bce03c3f971"), 500, null, "Green", "DarkGreen" },
                    { new Guid("d44aed49-1933-4739-ad05-c41d97bf0b6d"), 100, null, "Blue", "LightBlue" }
                });
        }
    }
}
