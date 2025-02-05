using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TagsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Entries_EntryEntityId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_EntryEntityId",
                table: "Tags");

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

            migrationBuilder.CreateTable(
                name: "EntryEntityTagEntity",
                columns: table => new
                {
                    EntryEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryTagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryEntityTagEntity", x => new { x.EntryEntityId, x.EntryTagsId });
                    table.ForeignKey(
                        name: "FK_EntryEntityTagEntity_Entries_EntryEntityId",
                        column: x => x.EntryEntityId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryEntityTagEntity_Tags_EntryTagsId",
                        column: x => x.EntryTagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("11383a9b-d0ca-4b1f-abee-fdecf0a49f8a"), null, "7 day streak", 0, 7 },
                    { new Guid("5ba1b8ff-2d18-4eb5-af37-7bf238d04d23"), null, "25 total entries", 1, 25 },
                    { new Guid("5e0adf75-4310-4dcd-99ef-b5257ccac7e1"), null, "50 total entries", 1, 50 },
                    { new Guid("a5f77bf0-284e-4660-9b94-d59487316544"), null, "10 total entries", 1, 10 },
                    { new Guid("d05c28cc-bcfd-462a-9256-5cad58747b10"), null, "3 day streak", 0, 3 },
                    { new Guid("f25f69d4-2bc3-4ba9-914f-4b466f9ec56a"), null, "5 day streak", 0, 5 },
                    { new Guid("fed5383d-b9dd-4fc8-a4bb-b4158471c04e"), null, "Your first entry", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryEntityTagEntity_EntryTagsId",
                table: "EntryEntityTagEntity",
                column: "EntryTagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryEntityTagEntity");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("11383a9b-d0ca-4b1f-abee-fdecf0a49f8a"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("5ba1b8ff-2d18-4eb5-af37-7bf238d04d23"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("5e0adf75-4310-4dcd-99ef-b5257ccac7e1"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("a5f77bf0-284e-4660-9b94-d59487316544"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("d05c28cc-bcfd-462a-9256-5cad58747b10"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("f25f69d4-2bc3-4ba9-914f-4b466f9ec56a"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("fed5383d-b9dd-4fc8-a4bb-b4158471c04e"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Tags_EntryEntityId",
                table: "Tags",
                column: "EntryEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Entries_EntryEntityId",
                table: "Tags",
                column: "EntryEntityId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
