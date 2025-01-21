﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gut_Cleanse.Data.Tables
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(250)]
        public string? MiddleName { get; set; }
        [StringLength(250)]
        [Required]
        public string LastName { get; set; }
        [StringLength(10)]
        [Required]
        public string ContactNumber { get; set; }
        [StringLength(250)]
        [Required]
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }
        [StringLength(6)]
        [Required]
        public string ZipCode { get; set; }
        [StringLength(10)]
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateOnly DOB { get; set; }
        public string? ProfilePicture { get; set; }
        [StringLength(255)]
        [Required]
        public string AspNetUserId { get; set; }
        public virtual City City { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
