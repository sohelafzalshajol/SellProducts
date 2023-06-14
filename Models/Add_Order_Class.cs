using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace SohelAfzalShajol_Playon24.Models
{
    public class Add_Order_Class
    {
        [Key]
        public int Pro_Order_ID { get; set; }
        public int Product_ID { get; set; }
        public int Customer_ID { get; set; }
        public int Quantity { get; set; }
        public double Total_Cost { get; set; }
        public bool IsActive { get; set; }
    }
}