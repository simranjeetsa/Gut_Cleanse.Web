using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Model
{
    public class PaymentModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string OrderId { get; set; }
        [StringLength(500)]
        public string PaymentId { get; set; }
        [Required]
        public int ProgramId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        [StringLength(10)]
        public string ContactNumber { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public string? RazorPayKeyId { get; set; }
        public string? Currency { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
    }
}
