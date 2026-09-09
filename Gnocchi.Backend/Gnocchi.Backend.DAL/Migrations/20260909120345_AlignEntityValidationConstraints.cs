using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gnocchi.Backend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AlignEntityValidationConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Results",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_Type",
                table: "Variants",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_Rating",
                table: "Scores",
                column: "Rating");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_EdibleRaw",
                table: "Ingredients",
                column: "EdibleRaw");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Name",
                table: "Dishes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CookingMethods_Method",
                table: "CookingMethods",
                column: "Method");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Variants_Type",
                table: "Variants");

            migrationBuilder.DropIndex(
                name: "IX_Scores_Rating",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_EdibleRaw",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_Name",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_CookingMethods_Method",
                table: "CookingMethods");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Results",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
