using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test3.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyForCategoryDanhsachRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniversityId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UniversityId",
                table: "Categories",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Danhsaches_UniversityId",
                table: "Categories",
                column: "UniversityId",
                principalTable: "Danhsaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Danhsaches_UniversityId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UniversityId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Categories");
        }
    }
}
