using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Model
{
    public class PaymentTypeModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        [Required]
        [StringLength(Int32.MaxValue)]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? PaymentContent { get; set; }
    }
}
