using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Gut_Cleanse.Model
{
    public class TestimonialModel
    {
        public int Id { get; set; }
   
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public int ProgramId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
