using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gut_Cleanse.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_entry_in_role_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8be1565d-f04c-11ef-a6eb-bc2411ffd154", null, "User", "USER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8be1565d-f04c-11ef-a6eb-bc2411ffd154");
        }
    }
}
