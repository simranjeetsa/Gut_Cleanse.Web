using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Data.Tables
{
    public class Testimonial
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string Name { get; set; }
        [StringLength(Int32.MaxValue)]
        public string Description { get; set; }
        [StringLength(250)]
        public string CreatedBy { get; set; }
        [ForeignKey("Programs")]
        public int ProgramId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Program Programs { get; set; }
    }
}
