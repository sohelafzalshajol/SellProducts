using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace SohelAfzalShajol_Playon24.Models
{
    public class Get_Pro_Class
    {
        [Key]
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Pro_Description { get; set; }
        public string Pro_Category { get; set; }
        public double Pro_Price { get; set; }
        public int Pro_Stock { get; set; }
        public string Pro_img { get; set; }
        public string Pro_img_name { get; set; }
        public bool IsActive { get; set; }
    }
}