using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIAssessment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerAccounts",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerAccounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCasinoWagers",
                columns: table => new
                {
                    WagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfBets = table.Column<int>(type: "int", nullable: false),
                    SessionData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCasinoWagers", x => x.WagerId);
                    table.ForeignKey(
                        name: "FK_PlayerCasinoWagers_PlayerAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "PlayerAccounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PlayerAccounts",
                columns: new[] { "AccountId", "Username" },
                values: new object[,]
                {
                    { new Guid("70f8f4dd-f621-40b8-9692-eac3f7e4a667"), "Sentle.Morake88" },
                    { new Guid("72e2cae1-4ec0-4f00-8c7a-29caba70f4b4"), "Bova.Senoinoi11" },
                    { new Guid("daf35aad-7654-4085-868f-27347ef2e522"), "Max.Booth67" }
                });

            migrationBuilder.InsertData(
                table: "PlayerCasinoWagers",
                columns: new[] { "WagerId", "AccountId", "Amount", "BrandId", "CountryCode", "CreatedDateTime", "Duration", "ExternalReferenceId", "GameName", "NumberOfBets", "Provider", "SessionData", "Status", "Theme", "TransactionId", "TransactionTypeId" },
                values: new object[,]
                {
                    { new Guid("57751b73-0a4f-4738-9c56-99acb8ed2373"), new Guid("70f8f4dd-f621-40b8-9692-eac3f7e4a667"), 52450.12m, new Guid("d243d980-44ec-4715-a793-30c0c9eb39a0"), "ZAR", new DateTime(2024, 9, 27, 13, 14, 56, 692, DateTimeKind.Utc).AddTicks(7072), 2657842L, new Guid("00000000-0000-0000-0000-000000000000"), "Mystery of the Lost Tomb", 5, "Ultimate Games Ltd", "Sample session data for mystery game", 0, "Mystery", new Guid("624afb15-90ab-433a-a5b0-f05d1a653102"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a16f1fb9-98bd-47fe-bd63-2f16fb088acc"), new Guid("72e2cae1-4ec0-4f00-8c7a-29caba70f4b4"), 19834.75m, new Guid("5cc2e173-1de5-4a86-aacc-9b5403c8c079"), "ZAR", new DateTime(2024, 9, 27, 13, 14, 56, 692, DateTimeKind.Utc).AddTicks(7077), 1458721L, new Guid("00000000-0000-0000-0000-000000000000"), "Starscape Galaxy Quest", 2, "Next Gen Gaming", "Sample session data for space game", 0, "Space", new Guid("533efc4c-bffc-464e-a412-34b1948b6b58"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e4993f13-3bde-4f82-a85c-4618e5cdc037"), new Guid("daf35aad-7654-4085-868f-27347ef2e522"), 38273.97m, new Guid("b93d8830-70be-48e8-82d9-3e66bba13f96"), "ZAR", new DateTime(2024, 9, 27, 13, 14, 56, 692, DateTimeKind.Utc).AddTicks(7044), 1827254L, new Guid("00000000-0000-0000-0000-000000000000"), "Ergonomic Granite Cheese", 3, "Ergonomic Soft Fish", "Sample session data", 0, "Adventure", new Guid("d09b25ba-2f8a-478d-b2a6-86ff7c651ebc"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCasinoWagers_AccountId",
                table: "PlayerCasinoWagers",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerCasinoWagers");

            migrationBuilder.DropTable(
                name: "PlayerAccounts");
        }
    }
}
