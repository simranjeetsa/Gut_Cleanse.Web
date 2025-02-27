using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Gut_Cleanse.Data.Tables
{
    public class Program
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(1000)]
        public string Name { get; set; }
        [Required]
        [StringLength(Int32.MaxValue)]
        public string Description { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? PaymentContent { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Testimonial> Testimonials { get; set; }
        public ICollection<ProgramDetail> ProgramDetails { get; set; }
    }
}
