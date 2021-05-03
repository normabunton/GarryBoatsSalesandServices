using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarryBoats.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string FullName { get; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string  EmailAddress { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
    }
}