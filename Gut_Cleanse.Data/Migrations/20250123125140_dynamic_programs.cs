using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gut_Cleanse.Data.Migrations
{
    /// <inheritdoc />
    public partial class dynamic_programs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentTypes_PaymentTypeId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.RenameColumn(
                name: "PaymentTypeId",
                table: "Payments",
                newName: "ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_PaymentTypeId",
                table: "Payments",
                newName: "IX_Payments_ProgramId");

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", maxLength: 2147483647, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProgramDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", maxLength: 2147483647, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramDetails_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", maxLength: 2147483647, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedBy = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testimonials_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "Amount", "Description", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 45000m, "Transform your relationship with health through our signature wellness program, crafted from over a decade of clinical success stories", new DateOnly(2025, 4, 5), "1:1 Gut Reset Revolution", new DateOnly(2025, 1, 6) },
                    { 2, 6300m, "Stop letting digestive issues control your life. Our Gut & Glory™ program helps you break free from constant bloating, weird food reactions", new DateOnly(2025, 1, 18), "Gut & Glory", new DateOnly(2025, 1, 5) },
                    { 3, 299m, "Discover how a thriving gut ecosystem shapes your physical and mental wellbeing through this transformative online workshop", new DateOnly(2025, 1, 12), "Gut Intelligence Workshop", new DateOnly(2025, 1, 12) },
                    { 4, 299m, "We created the 21-day challenge, a 3-week diet and workout routine, to help you lose weight and inches. We are going to create a personalized plan with simple recipes using ingredients that are already available in your pantry. We will consider your food preferences and health conditions before creating your diet.", null, "21 Day Challenge", null }
                });

            migrationBuilder.InsertData(
                table: "ProgramDetails",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "ProgramId" },
                values: new object[,]
                {
                    { 1, "Unlock lasting vitality by harmonizing your gut health, hormone balance, and mindful eating practices through this signature wellness program, crafted from over a decade of clinical success stories.", "/Assets/gutoo.jpg", "Your Relationship with Health through the 1:1 Gut Reset Revolution", 1 },
                    { 2, "<ul class=\"list-item\"><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Personalized 3-6 Month Journey with a dedicated nutrition expert guiding your transformation</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> 60-Minute Initial Consultation to map out your wellness journey and set personalized goals</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Custom Supplement Protocols tailored to your body’s needs for optimal health</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Blood Work Analysis &amp; Interpretation to ensure strategic health monitoring</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Flexible Meal Planning designed to fit your lifestyle and ensure long-term sustainability</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Bi-Weekly Check-Ins for continuous support, progress tracking, and adjustments                      </h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Mindful Eating Guidance to shift eating from stress to a source of joy</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Holistic Approach addressing gut health, hormone balance, and behavioral psychology</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Continuous WhatsApp Support for ongoing accountability and expert guidance</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Pregnancy/Postpartum Support for expert nutrition and wellness advice during your pregnancy journey or recovery</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Behavioral Psychology Insights to tackle stress and foster a positive relationship with food</h4></li></ul>", "/Assets/IMG_9684.jpg", "What is included in this Workshop?", 1 },
                    { 3, "Your gut is the foundation of your overall health. It’s not just about digestion – your gut influences your immune system, hormone balance, energy levels, and even your mood. When your gut is out of balance, it can lead to a cascade of issues, including digestive discomfort, hormone imbalances, and mental health challenges.", null, "Why Start With Gut Health?", 1 },
                    { 4, "Transform your health journey with expert guidance and practical solutions for just ₹45000. True health transformation begins with gut healing. Join the 1:1 Gut Reset Revolution and start optimizing your gut health, hormone balance, and overall wellness with personalized support.", null, "Limited Time Offer", 1 },
                    { 5, null, null, "Reserve your spot now and reclaim your health with a sustainable, holistic approach to wellness.", 1 },
                    { 6, "<div class=\"about-text  \"><p>Ever notice how a troubled stomach seems to affect everything? That's no coincidence. Your gut isn't just about digestion – it's your body's command center. When it's out of whack, you feel it everywhere: your mood tanks, your energy disappears, and even your favorite foods become enemies.</p><p class=\"mb-5\">Stop letting digestive issues control your life. Gut &amp; Glory™ helps you break free from bloating, weird food reactions, and that frustrating afternoon energy crash. In just 14 days, you'll discover how amazing you can feel when your gut works with you, not against you.</p></div>", "/Assets/gutoo.jpg", "Your 14-Day Journey to Digestive Freedom", 2 },
                    { 7, "<ul class=\"list-item ponter-text\"><p><b>14-Day Transformation Plan with Expert Guidance</b></p><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Kick-off Group Session: Set yourself up for success with an interactive group session led by your gut health expert.</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> 60-Minute Initial Consultation to map out your wellness journey and set personalized goals</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Weekly One-on-One Check-Ins: Stay on track with personalized support from your gut health coach.</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Blood Work Analysis &amp; Interpretation to ensure strategic health monitoring</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Direct WhatsApp Access: Get help during those \"what do I eat?\" moments with easy access to your coach.</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Bi-Weekly Check-Ins for continuous support, progress tracking, and adjustments</h4></li><p><b>Personalized Nutrition &amp; Support</b></p><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Custom Meal Plans: Enjoy meal plans designed specifically for your life and needs.</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Gut-Healing Recipe Collection: Delicious, gut-friendly recipes that make healing enjoyable.</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Daily Group Check-ins: Stay motivated and accountable through daily check-ins in a supportive community.</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Post-Program Maintenance Guide: Keep your gut health thriving after the program ends.</h4></li></ul>", "/Assets/IMG_9684.jpg", "What is Included in the Gut & Glory™ Program?", 2 },
                    { 8, "Starting with gut health is the key to unlocking overall wellness because your gut is the foundation of your physical and mental well-being. When your gut is in balance, it not only improves digestion but also boosts energy, sharpens mental clarity, regulates mood, and strengthens immunity. By addressing gut issues, you can say goodbye to bloating, fatigue, and food sensitivities, while enhancing nutrient absorption and maintaining a healthy weight. Focusing on gut health through the Gut & Glory™ program will empower you to take control of your health, leading to lasting vitality and a more vibrant life.", null, "Why Start With Gut Health?", 2 },
                    { 9, "Transform your health in just 14 days with Gut & Glory™, now available for an exclusive price of ₹6300! This limited-time offer includes expert guidance, personalized support, and proven strategies to help you reclaim your gut health and vitality. Don't miss your chance to experience the life-changing benefits of a healthy gut at a fraction of the cost. Secure your spot today and start your journey to digestive freedom!", null, "Limited Time Offer", 2 },
                    { 10, null, null, "Reserve your spot now for just ₹6300 and begin your path to optimal health!", 2 },
                    { 11, "Discover how a thriving gut ecosystem shapes your physical and mental wellbeing through this transformative online workshop.", "/Assets/gutoo.jpg", "Master Your Microbiome, Transform Your Health", 3 },
                    { 12, "<ul class=\"list-item\"><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> 2 Hour Live Zoom Session With  Gut Health expert Nancy</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> A guide to identify n address gut dysfunction</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Supplements &amp; tips to improve gut health</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> List of gut healing foods</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Understanding stool testing</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Guide to manage gut issues without medication</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Enriched Indian meal plans, healthy for your GUT.</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Q&amp;A on the topics discussed.  Investment in Your Health</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" srcset=\"/_next/image?url=%2Fdna.png&amp;w=640&amp;q=75 640w, /_next/image?url=%2Fdna.png&amp;w=750&amp;q=75 750w, /_next/image?url=%2Fdna.png&amp;w=828&amp;q=75 828w, /_next/image?url=%2Fdna.png&amp;w=1080&amp;q=75 1080w, /_next/image?url=%2Fdna.png&amp;w=1200&amp;q=75 1200w, /_next/image?url=%2Fdna.png&amp;w=1920&amp;q=75 1920w, /_next/image?url=%2Fdna.png&amp;w=2048&amp;q=75 2048w, /_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75 3840w\" src=\"/_next/image?url=%2Fdna.png&amp;w=3840&amp;q=75\" style=\"color: transparent; width: auto; height: auto;\"></span> Understanding SIBO - (small intestine bacterial overgrowth) and managing it</h4></li></ul>", "/Assets/IMG_9684.jpg", "What is included in this Workshop?", 3 },
                    { 13, "Your gut isn't just about digestion – it's your body's command center. When you optimize your gut health, you're laying the foundation for total wellness, from improved energy to better mood and clearer thinking.", null, "Why Start With Gut Health?", 3 },
                    { 14, "Transform your health journey with expert guidance and practical solutions at just ₹299. Secure your spot today and receive exclusive bonuses worth ₹6,000.\r\nRemember: True health transformation begins with gut healing. Join us to learn how to reprogram your gut and automate your path to wellness.", null, "Limited Time Offer", 3 },
                    { 15, null, null, "Reserve your spot now at ₹299 and begin your journey to optimal health.", 3 }
                });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "CreatedBy", "Description", "Name", "ProgramId" },
                values: new object[,]
                {
                    { 1, "Kannu", "I had a major bloating issue since a few years… nothing seemed to be working till the time I joined Nancy for the gut cleansing diet and that is when the magic happened… it was a very doable diet which helped me find out that milk was not suiting me at all which led to severe bloating… with Nancy’s diet I got rid of this problem… since then I never had bloating again and now I can easily enjoy my cold coffee everyday… thank you Nancy… you’ve been a saviour 🙏❤️🙏", "What Our Clients Are Saying", 1 },
                    { 2, "Ankur", "Nancy's gut cleanse is the best thing that i did. I was extremely bloated with breathing issues. I had gone to multiple doctors who prescribed many medicines which didn't seem right. After 3 months of trying, I tried Nancy's gut cleanse and to my surprise the problem I was facing reduced 90%. I highly recommend her 2-week gut cleanse practice to everyone", "What Our Clients Are Saying", 1 },
                    { 3, "Arvind", "As someone who has struggled with persistent digestive issues like bloating, frequent bowel movements, and loose stools, I was hesitant to try yet another diet plan. However, the gut cleanse workshop recommended by dietitian Nancy Dehra proved to be a game-changer. I noticed a significant improvement in my symptoms. The bloating and frequent, loose bowel movements that I had come to accept as a normal part of my life reduced drastically. I am incredibly grateful to my dietitian Nancy Dehra for designing such an effective and transformative gut cleanse workshop. Her deep understanding of digestive health, coupled with a personalized approach, has given me a new lease on life. I would highly recommend her workshop to anyone struggling with similar digestive challenges.", "What Our Clients Are Saying", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDetails_ProgramId",
                table: "ProgramDetails",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_ProgramId",
                table: "Testimonials",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Programs_ProgramId",
                table: "Payments",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Programs_ProgramId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "ProgramDetails");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.RenameColumn(
                name: "ProgramId",
                table: "Payments",
                newName: "PaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_ProgramId",
                table: "Payments",
                newName: "IX_Payments_PaymentTypeId");

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "longtext", maxLength: 2147483647, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentTypes_PaymentTypeId",
                table: "Payments",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
