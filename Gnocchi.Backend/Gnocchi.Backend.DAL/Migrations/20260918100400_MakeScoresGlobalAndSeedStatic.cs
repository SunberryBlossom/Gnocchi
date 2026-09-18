using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gnocchi.Backend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MakeScoresGlobalAndSeedStatic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_AspNetUsers_UserId",
                table: "Scores");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f4c3b1a-2d5e-4f6a-9b7c-1e2f3a4b5c6d");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Scores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3796d13-4318-47d0-9d41-3b5674a2b91d", "c61a37e1-cbcd-4cab-8eb8-9abc244a007d", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "ScoreId", "Rating", "UserId" },
                values: new object[,]
                {
                    { "10000000-0000-0000-0000-000000000001", 0, null },
                    { "10000000-0000-0000-0000-000000000002", 1, null },
                    { "10000000-0000-0000-0000-000000000003", 2, null },
                    { "10000000-0000-0000-0000-000000000004", 3, null },
                    { "10000000-0000-0000-0000-000000000005", 4, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_AspNetUsers_UserId",
                table: "Scores",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_AspNetUsers_UserId",
                table: "Scores");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3796d13-4318-47d0-9d41-3b5674a2b91d");

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: "10000000-0000-0000-0000-000000000001");

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: "10000000-0000-0000-0000-000000000002");

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: "10000000-0000-0000-0000-000000000003");

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: "10000000-0000-0000-0000-000000000004");

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: "10000000-0000-0000-0000-000000000005");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Scores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f4c3b1a-2d5e-4f6a-9b7c-1e2f3a4b5c6d", "db5fd72c-5e52-43a4-830b-69047b0d233a", "admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_AspNetUsers_UserId",
                table: "Scores",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
