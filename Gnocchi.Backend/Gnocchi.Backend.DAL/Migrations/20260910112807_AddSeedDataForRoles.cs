using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gnocchi.Backend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataForRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f4c3b1a-2d5e-4f6a-9b7c-1e2f3a4b5c6d", "db5fd72c-5e52-43a4-830b-69047b0d233a", "admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f4c3b1a-2d5e-4f6a-9b7c-1e2f3a4b5c6d");
        }
    }
}
