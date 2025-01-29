using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Entries_EntryEntityId",
                table: "Tags");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("2b7783f6-776d-4522-bd8f-713cacba018d"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("4a7b35e9-7d11-4725-a1ab-da40087e20d0"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("51d2e6dc-c587-4367-8f4a-98b16df5b6da"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("669ae0a1-06ee-4adc-9682-7c19ee4df6c1"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("9fba1ab2-4948-43ab-b6b2-b1f5d09ed7ad"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("b245c56a-1646-40b9-999e-181269751833"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("f92eb28e-cae3-4b2f-896c-3afb9f82e31d"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("0b273dfc-9075-432b-a369-2eb9940e49d9"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("73fe338d-5f76-494e-a7b3-84baa5c17a5b"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("97c76c90-4ecc-4caf-b487-1f07c49f88cf"));

            migrationBuilder.AlterColumn<Guid>(
                name: "EntryEntityId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Entries_EntryEntityId",
                table: "Tags",
                column: "EntryEntityId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Entries_EntryEntityId",
                table: "Tags");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "EntryEntityId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("2b7783f6-776d-4522-bd8f-713cacba018d"), null, "Your first entry", 1, 1 },
                    { new Guid("4a7b35e9-7d11-4725-a1ab-da40087e20d0"), null, "3 day streak", 0, 3 },
                    { new Guid("51d2e6dc-c587-4367-8f4a-98b16df5b6da"), null, "25 total entries", 1, 25 },
                    { new Guid("669ae0a1-06ee-4adc-9682-7c19ee4df6c1"), null, "50 total entries", 1, 50 },
                    { new Guid("9fba1ab2-4948-43ab-b6b2-b1f5d09ed7ad"), null, "5 day streak", 0, 5 },
                    { new Guid("b245c56a-1646-40b9-999e-181269751833"), null, "7 day streak", 0, 7 },
                    { new Guid("f92eb28e-cae3-4b2f-896c-3afb9f82e31d"), null, "10 total entries", 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Cost", "DiaryUserEntityId", "PrimaryColor", "SecondaryColor" },
                values: new object[,]
                {
                    { new Guid("0b273dfc-9075-432b-a369-2eb9940e49d9"), 250, null, "Red", "DarkRed" },
                    { new Guid("73fe338d-5f76-494e-a7b3-84baa5c17a5b"), 500, null, "Green", "DarkGreen" },
                    { new Guid("97c76c90-4ecc-4caf-b487-1f07c49f88cf"), 100, null, "Blue", "LightBlue" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Entries_EntryEntityId",
                table: "Tags",
                column: "EntryEntityId",
                principalTable: "Entries",
                principalColumn: "Id");
        }
    }
}
