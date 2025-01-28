using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tags_TagEntityId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "EntryTagEntity");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TagEntityId",
                table: "Tags");

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
                name: "TagEntityId",
                table: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "DiaryUserEntityId",
                table: "Tags",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Tags_DiaryUserEntityId",
                table: "Tags",
                column: "DiaryUserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_AspNetUsers_DiaryUserEntityId",
                table: "Tags",
                column: "DiaryUserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_AspNetUsers_DiaryUserEntityId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_DiaryUserEntityId",
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

            migrationBuilder.DropColumn(
                name: "DiaryUserEntityId",
                table: "Tags");

            migrationBuilder.AddColumn<Guid>(
                name: "TagEntityId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: true);

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
                name: "IX_Tags_TagEntityId",
                table: "Tags",
                column: "TagEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryTagEntity_DiaryUserEntityId",
                table: "EntryTagEntity",
                column: "DiaryUserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryTagEntity_EntryId",
                table: "EntryTagEntity",
                column: "EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tags_TagEntityId",
                table: "Tags",
                column: "TagEntityId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}
