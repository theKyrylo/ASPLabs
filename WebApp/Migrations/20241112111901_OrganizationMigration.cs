using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "contact",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    NIP = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "contact",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OrganizationId" },
                values: new object[] { new DateTime(2024, 11, 12, 12, 19, 0, 481, DateTimeKind.Local).AddTicks(565), 1 });

            migrationBuilder.UpdateData(
                table: "contact",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OrganizationId" },
                values: new object[] { new DateTime(2024, 11, 12, 12, 19, 0, 481, DateTimeKind.Local).AddTicks(714), 2 });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "ID", "Address_City", "Address_Street", "NIP", "Name", "Region" },
                values: new object[,]
                {
                    { 1, "London", "Street", "17268734", "Famo", "7238492482" },
                    { 2, "Krakow", "Miodowa", "14368734", "Org", "7238495672" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contact_OrganizationId",
                table: "contact",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_contact_organizations_OrganizationId",
                table: "contact",
                column: "OrganizationId",
                principalTable: "organizations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contact_organizations_OrganizationId",
                table: "contact");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropIndex(
                name: "IX_contact_OrganizationId",
                table: "contact");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "contact");

            migrationBuilder.UpdateData(
                table: "contact",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 11, 11, 53, 49, 690, DateTimeKind.Local).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "contact",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 11, 11, 53, 49, 690, DateTimeKind.Local).AddTicks(2522));
        }
    }
}
