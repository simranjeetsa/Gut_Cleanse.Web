using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gut_Cleanse.Data.Migrations
{
    /// <inheritdoc />
    public partial class addprogramcontent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentContent",
                table: "Programs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Programs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentContent",
                value: "<div id=\"description-details\">\r\n                                <div class=\"title title--big\" tabindex=\"1\">\r\n                                    1:1 Gut Reset Revolution (3 months)\r\n                                    <div class=\"title-underline\"></div>\r\n                                </div>\r\n\r\n\r\n\r\n                                <div id=\"description\">\r\n                                    <div id=\"description-quill\" tabindex=\"1\" class=\"ql-container ql-snow ql-disabled\">\r\n                                        <div class=\"ql-editor\" data-gramm=\"false\" contenteditable=\"false\">\r\n\r\n                                            <strong>1:1 Gut Reset Revolution (3 month program)</strong>\r\n                                            <p>Transform your relationship with health through our signature wellness program, crafted from over a decade of clinical success stories. We don't just address symptoms – we help you unlock lasting vitality by harmonizing your gut health, hormone balance, and mindful eating practices.</p>\r\n                                            <strong>The 1:1 Gut Reset Revolution Experience</strong>\r\n                                            <p>This intimate 3 month journey pairs you with a dedicated nutrition expert who guides your transformation through personalized nutrition, targeted supplementation, and sustainable lifestyle shifts. We move beyond quick fixes to create lasting change that works with your unique body and lifestyle.</p>\r\n                                            <strong>Is 1:1 Gut Reset Revolution Right for You?</strong>\r\n                                            <p>This program speaks to you if:</p>\r\n                                            <ul>\r\n                                                <li>You're navigating persistent digestive issues or hormone-related challenges that seem to worsen with certain foods</li>\r\n                                                <li>Traditional medications like birth control or acid reducers haven't provided the relief you're seeking</li>\r\n                                                <li>You're tired of the yo-yo effect from jumping between restrictive diets</li>\r\n                                                <li>Eating has become a source of stress rather than pleasure</li>\r\n                                                <li>You're seeking expert guidance during your pregnancy journey or postpartum recovery</li>\r\n                                            </ul>\r\n                                            <p><button class=\"btn-link hideButton\" onclick=\"showMore()\">Show More</button></p>\r\n\r\n                                        </div>\r\n\r\n                                    </div>\r\n                                </div>\r\n\r\n                                <div id=\"description\" class=\"hideContent\" style=\"display:none;\">\r\n                                    <div id=\"description-quill\" tabindex=\"1\" class=\"ql-container ql-snow ql-disabled\">\r\n                                        <div class=\"ql-editor\" data-gramm=\"false\" contenteditable=\"false\">\r\n\r\n\r\n                                            <strong>Your Comprehensive Support System Includes:</strong>\r\n                                            <p>A foundation of personalized care through:</p>\r\n                                            <ul>\r\n                                                <li>An in-depth 60-minute initial consultation to map your wellness journey</li>\r\n                                                <li>Strategic health monitoring with blood work analysis and interpretation</li>\r\n                                                <li>Custom supplement protocols aligned with your body's needs</li>\r\n                                                <li>Flexible meal planning that fits seamlessly into your life</li>\r\n                                                <li>Bi-weekly check-ins and continuous WhatsApp support for accountability</li>\r\n                                            </ul>\r\n                                        </div>\r\n\r\n                                    </div>\r\n                                </div>\r\n                            </div>");

            migrationBuilder.UpdateData(
                table: "Programs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PaymentContent",
                value: null);

            migrationBuilder.UpdateData(
                table: "Programs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PaymentContent",
                value: null);

            migrationBuilder.UpdateData(
                table: "Programs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PaymentContent",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentContent",
                table: "Programs");
        }
    }
}
