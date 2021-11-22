using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AdminTemplate.Models
{
    public class Custom_validation
    {
        [Required]
        [Display(Name = "Name")]
        [MaxLength(20, ErrorMessage = "Max 20 characters")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [MaxLength(100, ErrorMessage = "Max 100 characters")]
        public string User_Name { get; set; }
        [Required]
        [Display(Name = "Password")]
        [MaxLength(8, ErrorMessage = "Max 8 characters")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Contact No")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Contact_No { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}