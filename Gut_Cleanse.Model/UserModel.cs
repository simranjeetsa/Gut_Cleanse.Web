using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Model
{
    public class UserModel
    {
        public UserModel()
        {
            Countries = new List<CountryModel>();
            States = new List<StateModel>();
            Cities = new List<CityModel>();
        }
        public int Id { get; set; }
        [StringLength(250)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(250)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [StringLength(250)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(10)]
        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [StringLength(250)]
        [Required]
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        [Required]
        public int? CityId { get; set; }
        [StringLength(6)]
        [Required]
        public string ZipCode { get; set; }
        [StringLength(10)]
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateOnly? DOB { get; set; }
        public string? ProfilePicture { get; set; }

        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public string AspNetUserId { get; set; }
        public List<CountryModel> Countries { get; set; }
        public List<StateModel> States { get; set; }
        public List<CityModel> Cities { get; set; }
    }
}
