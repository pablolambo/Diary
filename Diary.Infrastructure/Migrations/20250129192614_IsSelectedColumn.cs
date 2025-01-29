using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsSelectedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Themes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("27cffa43-aafe-4e39-9366-7c3b405b0e1a"), null, "3 day streak", 0, 3 },
                    { new Guid("3e4dea70-6a70-4699-9301-1dd588eac34e"), null, "7 day streak", 0, 7 },
                    { new Guid("617ec744-c053-45a9-be66-55e34f8ffe3f"), null, "5 day streak", 0, 5 },
                    { new Guid("7c904f28-0e5f-46d8-b6d4-97623e6da04e"), null, "25 total entries", 1, 25 },
                    { new Guid("91441502-33e5-4acc-be58-bac8db5d3fa7"), null, "Your first entry", 1, 1 },
                    { new Guid("9b817c1f-b76a-425b-af50-701763ec19f4"), null, "50 total entries", 1, 50 },
                    { new Guid("a76a74ff-0327-4db1-8327-43948e633e78"), null, "10 total entries", 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Cost", "DiaryUserEntityId", "IsBought", "IsSelected", "PrimaryColor", "SecondaryColor" },
                values: new object[,]
                {
                    { new Guid("220212e0-75db-4dec-ba9d-4709bb7b7c30"), 500, null, false, false, "Green", "DarkGreen" },
                    { new Guid("5b8e5f71-06dd-44e9-ae0d-d88c42962871"), 250, null, false, false, "Red", "DarkRed" },
                    { new Guid("dca1063b-2a8d-44c0-ad4a-aa036bc65d63"), 100, null, false, false, "Blue", "LightBlue" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("27cffa43-aafe-4e39-9366-7c3b405b0e1a"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("3e4dea70-6a70-4699-9301-1dd588eac34e"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("617ec744-c053-45a9-be66-55e34f8ffe3f"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("7c904f28-0e5f-46d8-b6d4-97623e6da04e"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("91441502-33e5-4acc-be58-bac8db5d3fa7"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("9b817c1f-b76a-425b-af50-701763ec19f4"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("a76a74ff-0327-4db1-8327-43948e633e78"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("220212e0-75db-4dec-ba9d-4709bb7b7c30"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("5b8e5f71-06dd-44e9-ae0d-d88c42962871"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("dca1063b-2a8d-44c0-ad4a-aa036bc65d63"));

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Themes");

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
    }
}
