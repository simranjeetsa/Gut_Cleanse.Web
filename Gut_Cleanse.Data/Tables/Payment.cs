using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Data.Tables
{
    public class Payment
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string OrderId { get; set; }
        [StringLength(500)]
        public string PaymentId { get; set; }
        [Required]
        [ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }
        [Required]
        [Precision(18, 2)]
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
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual User User { get; set; }


    }
}
