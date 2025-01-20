using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Data.Tables
{
    public class PaymentType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        [Required]
        [StringLength(Int32.MaxValue)]
        public string Description { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
