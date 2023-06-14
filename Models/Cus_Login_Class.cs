using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace SohelAfzalShajol_Playon24.Models
{
    public class Cus_Login_Class
    {
		[Key]
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Email")]
		[Display(Name = "Customer Email")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Cus_Email { get; set; }

		[Required(ErrorMessage = "Please Enter Password")]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Cus_Password { get; set; }

		[Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}