using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NullableFirebaseToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "FirebaseToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("0eab4d32-c026-40d7-8ad1-c6e42ba0dbf2"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("35b5c319-b65f-46ac-9b74-bf78103dad79"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("e378f4dd-cf18-489e-937d-a81c40d8836b"));

            migrationBuilder.AlterColumn<string>(
                name: "FirebaseToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
