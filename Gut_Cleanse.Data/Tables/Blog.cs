using System.ComponentModel.DataAnnotations;

namespace Gut_Cleanse.Data.Tables
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string Title { get; set; }
        [StringLength(Int32.MaxValue)]
        public string? MainDescription { get; set; }
        [StringLength(Int32.MaxValue)]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateOnly CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
