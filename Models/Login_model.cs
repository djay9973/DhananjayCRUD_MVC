using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace AdminTemplate.Models
{

    public class Login_model
    {
        [Required(ErrorMessage = "Please enter user name.")]
        [Display(Name = "User Name")]
        public string user_name { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}