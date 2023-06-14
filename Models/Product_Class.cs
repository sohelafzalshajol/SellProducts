using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace SohelAfzalShajol_Playon24.Models
{
    public class Product_Class
    {
        public int Action { get; set; }

        [Key]
        public int Product_ID { get; set; }

        [Required(ErrorMessage = "Please Enter Product Name")]
        [Display(Name = "Product Name")]
        public string Product_Name { get; set; }

        [Required(ErrorMessage = "Please Enter Product Description")]
        [Display(Name = "Product Description")]
        public string Pro_Description { get; set; }

        [Required(ErrorMessage = "Please Select Product Category")]
        [Display(Name = "Product Category")]
        public string Pro_Category { get; set; }

        [Required(ErrorMessage = "Please Enter Product Price")]
        [Display(Name = "Product Price")]
        public float Pro_Price { get; set; }

        [Required(ErrorMessage = "Please Enter Product Stock")]
        [Display(Name = "Product Stock")]
        public int Pro_Stock { get; set; }

        [Required(ErrorMessage = "Please Give A Product Image")]
        [Display(Name = "Product Image")]
        public string Pro_img { get; set; }

        public string Pro_img_name { get; set; }

        public int EntryBy { get; set; }

        [Required(ErrorMessage = "Please Select Active Status")]
        [Display(Name = "Active Status")]
        public bool IsActive { get; set; }
    }
}