using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Model
{
    public class ProgramViewModel
    {
        public IEnumerable<TestimonialModel> TestimonialPrograms { get; set; }
        public IEnumerable<ProgramDetailModel> ProgramDetail { get; set; }
    }
}
