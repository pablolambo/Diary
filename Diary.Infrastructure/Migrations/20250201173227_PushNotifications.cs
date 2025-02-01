using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PushNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "FirebaseToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("3dfabcb7-10c1-4f6e-8572-6d4963946098"), null, "3 day streak", 0, 3 },
                    { new Guid("65c7231e-1fd7-4900-a625-2235f56ce19b"), null, "Your first entry", 1, 1 },
                    { new Guid("7ae2f3fd-ee4d-4626-8d5a-546dac50c9fe"), null, "50 total entries", 1, 50 },
                    { new Guid("b4cd1a0c-44e3-4a30-89f2-3f6b68101476"), null, "5 day streak", 0, 5 },
                    { new Guid("eed1123c-bb39-49c6-b9f2-8931c2393157"), null, "7 day streak", 0, 7 },
                    { new Guid("f287c6f7-751d-4049-9b24-b6b65544cbde"), null, "10 total entries", 1, 10 },
                    { new Guid("fbce8d48-a6cb-4f6f-b036-3d3b55550feb"), null, "25 total entries", 1, 25 }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Cost", "DiaryUserEntityId", "IsBought", "IsSelected", "PrimaryColor", "SecondaryColor" },
                values: new object[,]
                {
                    { new Guid("8f18db4a-a7ee-40fd-a648-cbd90f35dfad"), 100, null, false, false, "Blue", "LightBlue" },
                    { new Guid("95a411ec-083a-4fd5-a199-8c159982f5a2"), 250, null, false, false, "Red", "DarkRed" },
                    { new Guid("a05ec7fa-0576-4120-a2f6-47e933f52ede"), 500, null, false, false, "Green", "DarkGreen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("3dfabcb7-10c1-4f6e-8572-6d4963946098"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("65c7231e-1fd7-4900-a625-2235f56ce19b"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("7ae2f3fd-ee4d-4626-8d5a-546dac50c9fe"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("b4cd1a0c-44e3-4a30-89f2-3f6b68101476"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("eed1123c-bb39-49c6-b9f2-8931c2393157"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("f287c6f7-751d-4049-9b24-b6b65544cbde"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("fbce8d48-a6cb-4f6f-b036-3d3b55550feb"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("8f18db4a-a7ee-40fd-a648-cbd90f35dfad"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("95a411ec-083a-4fd5-a199-8c159982f5a2"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("a05ec7fa-0576-4120-a2f6-47e933f52ede"));

            migrationBuilder.DropColumn(
                name: "FirebaseToken",
                table: "AspNetUsers");

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
    }
}
