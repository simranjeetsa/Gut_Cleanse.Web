using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Gut_Cleanse.Model
{
    public class ProgramDetailModel
    {
       
        public int Id { get; set; }
     
        public string Name { get; set; }

        [AllowHtml]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    
        public int ProgramId { get; set; }

    }
}
