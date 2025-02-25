using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gut_Cleanse.Data.Migrations
{
    /// <inheritdoc />
    public partial class saveImage_blogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/Assets/blog1.jpg");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/Assets/blog2.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: null);
        }
    }
}
