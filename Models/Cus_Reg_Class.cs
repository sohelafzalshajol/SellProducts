using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace SohelAfzalShajol_Playon24.Models
{
    public class Cus_Reg_Class
    {
		[Required(ErrorMessage = "Please Enter Customer Name")]
		[Display(Name = "Customer Name")]
        	public string Customer_Name { get; set; }

		[Required(ErrorMessage = "Please Enter Customer Email")]
		[Display(Name = "Customer Email")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Cus_Email { get; set; }

		[Required(ErrorMessage = "Please Select Customer Gender")]
		[Display(Name = "Customer Gender")]
		public char Cus_Gender { get; set; }

		[Required(ErrorMessage = "Please Select Customer Type")]
		[Display(Name = "Customer Type")]
		public string Cus_Type { get; set; }

		[Required(ErrorMessage = "Please Enter Password")]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Cus_Password { get; set; }

		[Required(ErrorMessage = "Please Enter Confirmed Password")]
		[Display(Name = "Confirmed Password")]
		[DataType(DataType.Password)]
		[Compare("Cus_Password")]
		public string Cus_RePassword { get; set; }

		[Required(ErrorMessage = "Please Select Active Status")]
		[Display(Name = "Active Status")]
		public bool IsActive { get; set; }
	}
}