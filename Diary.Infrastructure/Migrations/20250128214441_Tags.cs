using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Tags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("3099c70c-5e94-4218-8a3a-7b9e906f3c93"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("63d60bc1-aa74-410b-a313-e0dc6e967a6d"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("9e31b7d7-b1ab-4600-b326-4ef682e32c1c"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("abbe3e8f-47cd-4b92-9391-62e220b35ee7"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("ed2bb551-b943-4c37-b144-6d1573905ed6"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("fd7f2140-458b-4d40-be00-27a6c0d821f7"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("05cc408f-dca7-49ae-8cce-d5f7ee3ceac8"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("ead45be1-f561-4d0d-9ffc-551dfe46b253"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("f092c256-4bfb-4af7-81f2-42c3b428382b"));

            migrationBuilder.AddColumn<bool>(
                name: "IsFavourite",
                table: "Entries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EntryTagEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiaryUserEntityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryTagEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryTagEntity_AspNetUsers_DiaryUserEntityId",
                        column: x => x.DiaryUserEntityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntryTagEntity_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntryEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TagEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Entries_EntryEntityId",
                        column: x => x.EntryEntityId,
                        principalTable: "Entries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Tags_TagEntityId",
                        column: x => x.TagEntityId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("149d6f49-6fd4-4011-ac25-16023a87fd51"), null, "50 total entries", 1, 50 },
                    { new Guid("174794e2-3f31-4d81-a989-4479c8adf4fb"), null, "3 day streak", 0, 3 },
                    { new Guid("33d07c3e-33bf-40bc-8e42-b6a0cd157670"), null, "Your first entry", 1, 1 },
                    { new Guid("4c923c59-1990-4f56-a735-81c8d956e343"), null, "25 total entries", 1, 25 },
                    { new Guid("4e5d6858-d2a1-473d-90ec-a99ab259af0d"), null, "10 total entries", 1, 10 },
                    { new Guid("9b1ebbaa-9c35-4c60-90c8-74b366926797"), null, "5 day streak", 0, 5 },
                    { new Guid("a6e6a2b2-80a8-497b-9b39-e0343abdcb6e"), null, "7 day streak", 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Cost", "DiaryUserEntityId", "PrimaryColor", "SecondaryColor" },
                values: new object[,]
                {
                    { new Guid("0a3ade2b-dee9-4730-b933-0a8f192f3722"), 250, null, "Red", "DarkRed" },
                    { new Guid("a1dc0df9-8757-4474-8cb9-efeb13130136"), 500, null, "Green", "DarkGreen" },
                    { new Guid("b067f9c2-0f49-4616-ae7d-035a5bfd0ae5"), 100, null, "Blue", "LightBlue" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryTagEntity_DiaryUserEntityId",
                table: "EntryTagEntity",
                column: "DiaryUserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryTagEntity_EntryId",
                table: "EntryTagEntity",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_EntryEntityId",
                table: "Tags",
                column: "EntryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagEntityId",
                table: "Tags",
                column: "TagEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserId_Name",
                table: "Tags",
                columns: new[] { "UserId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryTagEntity");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("149d6f49-6fd4-4011-ac25-16023a87fd51"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("174794e2-3f31-4d81-a989-4479c8adf4fb"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("33d07c3e-33bf-40bc-8e42-b6a0cd157670"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("4c923c59-1990-4f56-a735-81c8d956e343"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("4e5d6858-d2a1-473d-90ec-a99ab259af0d"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("9b1ebbaa-9c35-4c60-90c8-74b366926797"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("a6e6a2b2-80a8-497b-9b39-e0343abdcb6e"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("0a3ade2b-dee9-4730-b933-0a8f192f3722"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("a1dc0df9-8757-4474-8cb9-efeb13130136"));

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: new Guid("b067f9c2-0f49-4616-ae7d-035a5bfd0ae5"));

            migrationBuilder.DropColumn(
                name: "IsFavourite",
                table: "Entries");

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DiaryUserEntityId", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("3099c70c-5e94-4218-8a3a-7b9e906f3c93"), null, "10 total entries", 1, 10 },
                    { new Guid("63d60bc1-aa74-410b-a313-e0dc6e967a6d"), null, "50 total entries", 1, 50 },
                    { new Guid("9e31b7d7-b1ab-4600-b326-4ef682e32c1c"), null, "3 day streak", 0, 3 },
                    { new Guid("abbe3e8f-47cd-4b92-9391-62e220b35ee7"), null, "25 total entries", 1, 25 },
                    { new Guid("ed2bb551-b943-4c37-b144-6d1573905ed6"), null, "5 day streak", 0, 5 },
                    { new Guid("fd7f2140-458b-4d40-be00-27a6c0d821f7"), null, "7 day streak", 0, 7 }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Cost", "DiaryUserEntityId", "PrimaryColor", "SecondaryColor" },
                values: new object[,]
                {
                    { new Guid("05cc408f-dca7-49ae-8cce-d5f7ee3ceac8"), 250, null, "Red", "DarkRed" },
                    { new Guid("ead45be1-f561-4d0d-9ffc-551dfe46b253"), 100, null, "Blue", "LightBlue" },
                    { new Guid("f092c256-4bfb-4af7-81f2-42c3b428382b"), 500, null, "Green", "DarkGreen" }
                });
        }
    }
}
