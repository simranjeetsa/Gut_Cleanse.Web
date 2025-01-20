using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gut_Cleanse.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeEmailDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amouont",
                table: "Payments",
                newName: "Amount");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Payments",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Payments",
                newName: "Amouont");

            migrationBuilder.AlterColumn<int>(
                name: "Email",
                table: "Payments",
                type: "int",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
