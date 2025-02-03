﻿using Gut_Cleanse.Data.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gut_Cleanse.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //public ApplicationDbContext()
        //{

        //}
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ProgramDetail> ProgramDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Country>().HasData(
                   new() { Id = 1, Name = "India" },
                   new() { Id = 2, Name = "Australia" },
                    new() { Id = 3, Name = "USA" }
            );
            //Seeding State Master Data using HasData method
            builder.Entity<State>().HasData(
                new() { Id = 1, Name = "Punjab", CountryId = 1 },
                 new() { Id = 2, Name = "Himachal", CountryId = 1 }
            );
            //Seeding City Master Data using HasData method
            builder.Entity<City>().HasData(
                new() { Id = 1, Name = "Mohali", StateId = 1 },
                new() { Id = 2, Name = "Jalandhar", StateId = 1 },
                 new() { Id = 3, Name = "Ludhiana", StateId = 1 },
                  new() { Id = 4, Name = "Shimla", StateId = 2 },
                new() { Id = 5, Name = "Dharamshala", StateId = 2 },
                 new() { Id = 6, Name = "Mandi", StateId = 2 }
             );
            builder.Entity<IdentityRole>().HasData(
                 new IdentityRole() { Id = "F2362EB6-4C91-4E31-B822-A62032A68678", Name = "Admin", NormalizedName = "ADMIN" }
            );
            builder.Entity<Program>().HasData(
                 new Program() { Id = 1, Name = "1:1 Gut Reset Revolution", StartDate = new DateOnly(2025, 1, 6), EndDate = new DateOnly(2025, 4, 5), Amount = 45000, Description = "Transform your relationship with health through our signature wellness program, crafted from over a decade of clinical success stories" },
                 new Program() { Id = 2, Name = "Gut & Glory", StartDate = new DateOnly(2025, 1, 5), EndDate = new DateOnly(2025, 1, 18), Amount = 6300, Description = "Stop letting digestive issues control your life. Our Gut & Glory™ program helps you break free from constant bloating, weird food reactions" },
                 new Program() { Id = 3, Name = "Gut Intelligence Workshop", StartDate = new DateOnly(2025, 1, 12), EndDate = new DateOnly(2025, 1, 12), Amount = 299, Description = "Discover how a thriving gut ecosystem shapes your physical and mental wellbeing through this transformative online workshop" },
                 new Program() { Id = 4, Name = "21 Day Challenge", StartDate = null, EndDate = null, Amount = 299, Description = "We created the 21-day challenge, a 3-week diet and workout routine, to help you lose weight and inches. We are going to create a personalized plan with simple recipes using ingredients that are already available in your pantry. We will consider your food preferences and health conditions before creating your diet." }
            );
            builder.Entity<Testimonial>().HasData(
                new Testimonial() { Id = 1, ProgramId = 1, Name = "What Our Clients Are Saying", CreatedBy = "Kannu", Description = "I had a major bloating issue since a few years… nothing seemed to be working till the time I joined Nancy for the gut cleansing diet and that is when the magic happened… it was a very doable diet which helped me find out that milk was not suiting me at all which led to severe bloating… with Nancy’s diet I got rid of this problem… since then I never had bloating again and now I can easily enjoy my cold coffee everyday… thank you Nancy… you’ve been a saviour 🙏❤️🙏" },
                new Testimonial() { Id = 2, ProgramId = 1, Name = "What Our Clients Are Saying", CreatedBy = "Ankur", Description = "Nancy's gut cleanse is the best thing that i did. I was extremely bloated with breathing issues. I had gone to multiple doctors who prescribed many medicines which didn't seem right. After 3 months of trying, I tried Nancy's gut cleanse and to my surprise the problem I was facing reduced 90%. I highly recommend her 2-week gut cleanse practice to everyone" },
                new Testimonial() { Id = 3, ProgramId = 1, Name = "What Our Clients Are Saying", CreatedBy = "Arvind", Description = "As someone who has struggled with persistent digestive issues like bloating, frequent bowel movements, and loose stools, I was hesitant to try yet another diet plan. However, the gut cleanse workshop recommended by dietitian Nancy Dehra proved to be a game-changer. I noticed a significant improvement in my symptoms. The bloating and frequent, loose bowel movements that I had come to accept as a normal part of my life reduced drastically. I am incredibly grateful to my dietitian Nancy Dehra for designing such an effective and transformative gut cleanse workshop. Her deep understanding of digestive health, coupled with a personalized approach, has given me a new lease on life. I would highly recommend her workshop to anyone struggling with similar digestive challenges." }
           );
            builder.Entity<ProgramDetail>().HasData(
               new ProgramDetail() { Id = 1, ProgramId = 1, Name = "Your Relationship with Health through the 1:1 Gut Reset Revolution", ImageUrl = "/Assets/gutoo.jpg", Description = "Unlock lasting vitality by harmonizing your gut health, hormone balance, and mindful eating practices through this signature wellness program, crafted from over a decade of clinical success stories." },
               new ProgramDetail() { Id = 2, ProgramId = 1, Name = "What is included in this Workshop?", ImageUrl = "/Assets/IMG_9684.jpg", Description = "<ul class=\"list-item\">\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Personalized 3-6 Month Journey with a dedicated\r\n       nutrition expert guiding your transformation</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> 60-Minute Initial Consultation to map out your\r\n       wellness journey and set personalized goals</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Custom Supplement Protocols tailored to your\r\n       body’s needs for optimal health</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Blood Work Analysis &amp; Interpretation to\r\n       ensure strategic health monitoring</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Flexible Meal Planning designed to fit your\r\n       lifestyle and ensure long-term sustainability</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Bi-Weekly Check-Ins for continuous support,\r\n       progress tracking, and adjustments </h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Mindful Eating Guidance to shift eating from\r\n       stress to a source of joy</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Holistic Approach addressing gut health,\r\n       hormone balance, and behavioral psychology</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Continuous WhatsApp Support for ongoing\r\n       accountability and expert guidance</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Pregnancy/Postpartum Support for expert\r\n       nutrition and wellness advice during your pregnancy journey or recovery</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Behavioral Psychology Insights to tackle stress\r\n       and foster a positive relationship with food</h4>\r\n   </li>\r\n </ul>" },
               new ProgramDetail() { Id = 3, ProgramId = 1, Name = "Why Start With Gut Health?", ImageUrl = null, Description = "Your gut is the foundation of your overall health. It’s not just about digestion – your gut influences your immune system, hormone balance, energy levels, and even your mood. When your gut is out of balance, it can lead to a cascade of issues, including digestive discomfort, hormone imbalances, and mental health challenges." },
               new ProgramDetail() { Id = 4, ProgramId = 1, Name = "Limited Time Offer", ImageUrl = null, Description = "Transform your health journey with expert guidance and practical solutions for just ₹45000. True health transformation begins with gut healing. Join the 1:1 Gut Reset Revolution and start optimizing your gut health, hormone balance, and overall wellness with personalized support." },
               new ProgramDetail() { Id = 5, ProgramId = 1, Name = "Reserve your spot now and reclaim your health with a sustainable, holistic approach to wellness.", ImageUrl = null, Description = null },



               new ProgramDetail() { Id = 6, ProgramId = 2, Name = "Your 14-Day Journey to Digestive Freedom", ImageUrl = "/Assets/gutoo.jpg", Description = "<div class=\"about-text  \"><p>Ever notice how a troubled stomach seems to affect everything? That's no coincidence. Your gut isn't just about digestion – it's your body's command center. When it's out of whack, you feel it everywhere: your mood tanks, your energy disappears, and even your favorite foods become enemies.</p><p class=\"mb-5\">Stop letting digestive issues control your life. Gut &amp; Glory™ helps you break free from bloating, weird food reactions, and that frustrating afternoon energy crash. In just 14 days, you'll discover how amazing you can feel when your gut works with you, not against you.</p></div>" },
               new ProgramDetail() { Id = 7, ProgramId = 2, Name = "What is Included in the Gut & Glory™ Program?", ImageUrl = "/Assets/IMG_9684.jpg", Description = "<ul class=\"list-item ponter-text\">\r\n   <p><b>14-Day Transformation Plan with Expert Guidance</b></p>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Kick-off Group Session: Set yourself up for\r\n       success with an interactive group session led by your gut health expert.</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> 60-Minute Initial Consultation to map out your\r\n       wellness journey and set personalized goals</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Weekly One-on-One Check-Ins: Stay on track with\r\n       personalized support from your gut health coach.</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Blood Work Analysis &amp; Interpretation to\r\n       ensure strategic health monitoring</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Direct WhatsApp Access: Get help during those\r\n       \"what do I eat?\" moments with easy access to your coach.</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Bi-Weekly Check-Ins for continuous support,\r\n       progress tracking, and adjustments</h4>\r\n   </li>\r\n   <p><b>Personalized Nutrition &amp; Support</b></p>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Custom Meal Plans: Enjoy meal plans designed\r\n       specifically for your life and needs.</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Gut-Healing Recipe Collection: Delicious,\r\n       gut-friendly recipes that make healing enjoyable.</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Daily Group Check-ins: Stay motivated and\r\n       accountable through daily check-ins in a supportive community.</h4>\r\n   </li>\r\n   <li>\r\n     <h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\"\r\n           class=\"fa-spin\" sizes=\"100vw\"\r\n           src=\"/Assets/dna.png\"\r\n           style=\"color: transparent; width: auto; height: auto;\"></span> Post-Program Maintenance Guide: Keep your gut\r\n       health thriving after the program ends.</h4>\r\n   </li>\r\n </ul>" },
               new ProgramDetail() { Id = 8, ProgramId = 2, Name = "Why Start With Gut Health?", ImageUrl = null, Description = "Starting with gut health is the key to unlocking overall wellness because your gut is the foundation of your physical and mental well-being. When your gut is in balance, it not only improves digestion but also boosts energy, sharpens mental clarity, regulates mood, and strengthens immunity. By addressing gut issues, you can say goodbye to bloating, fatigue, and food sensitivities, while enhancing nutrient absorption and maintaining a healthy weight. Focusing on gut health through the Gut & Glory™ program will empower you to take control of your health, leading to lasting vitality and a more vibrant life." },
               new ProgramDetail() { Id = 9, ProgramId = 2, Name = "Limited Time Offer", ImageUrl = null, Description = "Transform your health in just 14 days with Gut & Glory™, now available for an exclusive price of ₹6300! This limited-time offer includes expert guidance, personalized support, and proven strategies to help you reclaim your gut health and vitality. Don't miss your chance to experience the life-changing benefits of a healthy gut at a fraction of the cost. Secure your spot today and start your journey to digestive freedom!" },
               new ProgramDetail() { Id = 10, ProgramId = 2, Name = "Reserve your spot now for just ₹6300 and begin your path to optimal health!", ImageUrl = null, Description = null },


               new ProgramDetail() { Id = 11, ProgramId = 3, Name = "Master Your Microbiome, Transform Your Health", ImageUrl = "/Assets/gutoo.jpg", Description = "Discover how a thriving gut ecosystem shapes your physical and mental wellbeing through this transformative online workshop." },
               new ProgramDetail() { Id = 12, ProgramId = 3, Name = "What is included in this Workshop?", ImageUrl = "/Assets/IMG_9684.jpg", Description = "<div class=\"about-text pr-5\"><ul class=\"list-item\"><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\"  src=\"/Assets/dna.png\"></span> 2 Hour Live Zoom Session With  Gut Health expert Nancy</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" src=\"/Assets/dna.png\"></span> A guide to identify n address gut dysfunction</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" src=\"/Assets/dna.png\"></span> Supplements &amp; tips to improve gut health</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\"  src=\"/Assets/dna.png\"></span> List of gut healing foods</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\"src=\"/Assets/dna.png\"></span> Understanding stool testing</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" src=\"/Assets/dna.png\"></span> Guide to manage gut issues without medication</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" src=\"/Assets/dna.png\"></span> Enriched Indian meal plans, healthy for your GUT.</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" src=\"/Assets/dna.png\"></span> Q&amp;A on the topics discussed.  Investment in Your Health</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" src=\"/Assets/dna.png\"></span> Understanding SIBO - (small intestine bacterial overgrowth) and managing it</h4></li></ul></div><div><div class=\"section-title-5 mb-20\"><h4><b>At ₹299 (less than your favorite pizza!), unlock:</b> </h4></div><ul class=\"list-item\"><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" src=\"/Assets/dna.png\"></span> Live expert-led workshop</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\" src=\"/Assets/dna.png\"></span> Comprehensive gut health resources</h4></li><li><h4><span class=\"\"><img alt=\"arrow\" loading=\"lazy\" width=\"0\" height=\"0\" decoding=\"async\" data-nimg=\"1\" class=\"fa-spin\" sizes=\"100vw\"  src=\"/Assets/dna.png\"></span> Exclusive bonuses worth ₹6,000</h4></li></ul></div>" },
               new ProgramDetail() { Id = 13, ProgramId = 3, Name = "Why Start With Gut Health?", ImageUrl = null, Description = "Your gut isn't just about digestion – it's your body's command center. When you optimize your gut health, you're laying the foundation for total wellness, from improved energy to better mood and clearer thinking." },
               new ProgramDetail() { Id = 14, ProgramId = 3, Name = "Limited Time Offer", ImageUrl = null, Description = "Transform your health journey with expert guidance and practical solutions at just ₹299. Secure your spot today and receive exclusive bonuses worth ₹6,000.\r\nRemember: True health transformation begins with gut healing. Join us to learn how to reprogram your gut and automate your path to wellness." },
               new ProgramDetail() { Id = 15, ProgramId = 3, Name = "Reserve your spot now at ₹299 and begin your journey to optimal health.", ImageUrl = null, Description = null }
          );
        }
    }
}
