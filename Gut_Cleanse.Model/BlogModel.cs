using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Model
{
    public class BlogModel
    {
 
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
   
        public string? MainDescription { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        [Display(Name = "Create Date")]
        public DateOnly CreateDate { get; set; }
    }
}

