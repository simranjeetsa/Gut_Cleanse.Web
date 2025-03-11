using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Gut_Cleanse.Model
{
    public class ProgramModel
    {
        public ProgramModel()
        {
            TestimonialPrograms = new List<TestimonialModel>();
        }
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
        public int? Count { get; set; }

        public List<TestimonialModel> TestimonialPrograms { get; set; }
        public List<ProgramDetailModel> ProgramDetail { get; set; }
     


    }
 

}
