using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gut_Cleanse.Data.Tables
{
    public class ProgramDetail
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string Name { get; set; }
        [StringLength(Int32.MaxValue)]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [ForeignKey("Programs")]
        public int ProgramId { get; set; }
        public virtual Program Programs { get; set; }
    }
}
