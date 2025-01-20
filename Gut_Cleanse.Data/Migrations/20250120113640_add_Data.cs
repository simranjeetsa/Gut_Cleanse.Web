using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gut_Cleanse.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amouont",
                table: "PaymentTypes",
                newName: "Amount");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "F2362EB6-4C91-4E31-B822-A62032A68678", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Amount", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 45000m, "Gut Reset Revolution", "Gut Reset Revolution" },
                    { 2, 6300m, "Gut & Glory", "Gut & Glory" },
                    { 3, 299m, "Gut Intelligence Workshop", "Gut Intelligence Workshop" },
                    { 4, 5000m, "21 Day Challenge", "21 Day Challenge" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F2362EB6-4C91-4E31-B822-A62032A68678");

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "PaymentTypes",
                newName: "Amouont");
        }
    }
}
