using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Gut_Cleanse.Model
{
    public class ProgramModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
 
        [AllowHtml]
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

    
        public List<TestimonialModel> TestimonialPrograms { get; set; }
        public List<ProgramDetailModel> ProgramDetail { get; set; }
     


    }
 

}
