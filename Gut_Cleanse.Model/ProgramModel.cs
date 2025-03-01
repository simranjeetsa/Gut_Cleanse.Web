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

        public string Name { get; set; }
 
        [AllowHtml]
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? Count { get; set; }

        public List<TestimonialModel> TestimonialPrograms { get; set; }
        public List<ProgramDetailModel> ProgramDetail { get; set; }

  

    }
 

}
