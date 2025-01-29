using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JustUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("02d6d0df-ed43-4644-8681-8b937742e0c5"), null, "25 total entries", 1, 25 },
                    { new Guid("14dfeba8-15f5-458f-8ebf-b9e43a2ad4e4"), null, "3 day streak", 0, 3 },
                    { new Guid("337a81ee-4616-4d16-ad99-a5f1423e12bd"), null, "50 total entries", 1, 50 },
                    { new Guid("8efc09da-282b-4e75-ae0c-b1abde72a384"), null, "Your first entry", 1, 1 },
                    { new Guid("a48a4dd1-9a62-4ea6-8b03-0896b6bcc600"), null, "10 total entries", 1, 10 },
                    { new Guid("ac8e7565-3ee9-483b-a811-72b0165dcd8e"), null, "5 day streak", 0, 5 },
                    { new Guid("b3c46cdf-4cc3-451c-9a99-859f0ab3587f"), null, "7 day streak", 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Cost", "DiaryUserEntityId", "IsBought", "IsSelected", "PrimaryColor", "SecondaryColor" },
                values: new object[,]
                {
                    { new Guid("4383b26a-0442-4728-b0b5-1ff089c5bfb4"), 250, null, false, false, "Red", "DarkRed" },
                    { new Guid("655e93c8-7e1d-465b-a4ca-813348750879"), 100, null, false, false, "Blue", "LightBlue" },
                    { new Guid("ad0146b0-9324-462e-9906-3bf4f7f56027"), 500, null, false, false, "Green", "DarkGreen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("02d6d0df-ed43-4644-8681-8b937742e0c5"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("14dfeba8-15f5-458f-8ebf-b9e43a2ad4e4"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("337a81ee-4616-4d16-ad99-a5f1423e12bd"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("8efc09da-282b-4e75-ae0c-b1abde72a384"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("a48a4dd1-9a62-4ea6-8b03-0896b6bcc600"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("ac8e7565-3ee9-483b-a811-72b0165dcd8e"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("b3c46cdf-4cc3-451c-9a99-859f0ab3587f"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("4383b26a-0442-4728-b0b5-1ff089c5bfb4"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("655e93c8-7e1d-465b-a4ca-813348750879"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("ad0146b0-9324-462e-9906-3bf4f7f56027"));

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
    }
}
