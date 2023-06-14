using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SohelAfzalShajol_Playon24.Models
{
    public class OrderInfoClass
    {
        [Key]
        public int Pro_Order_ID { get; set; }
        public int Product_ID { get; set; }
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Product_Name { get; set; }
        public int Quantity { get; set; }
        public double Pro_Price { get; set; }
        public double Total_Cost { get; set; }
        public DateTime Order_Date { get; set; }
        public bool IsActive { get; set; }
    }
}