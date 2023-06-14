using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using SohelAfzalShajol_Playon24.Models;

namespace SohelAfzalShajol_Playon24.Controllers
{
    public class GetProductController : Controller
    {
        // GET: GetProduct
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        [AllowAnonymous]
        public ActionResult Index()
        {
            SqlConnection sqlCon = new SqlConnection(conStr);
            SqlCommand sqlCmd = new SqlCommand("SP_Get_Products", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCon.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<Get_Pro_Class> GPC = new List<Get_Pro_Class>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (Convert.ToBoolean(dr["IsActive"]))
                {
                    GPC.Add(new Get_Pro_Class
                    {
                        Product_ID = Convert.ToInt32(dr["Product_ID"]),
                        Product_Name = Convert.ToString(dr["Product_Name"]),
                        Pro_Description = Convert.ToString(dr["Pro_Description"]),
                        Pro_Category = Convert.ToString(dr["Pro_Category"]),
                        Pro_Price = Convert.ToDouble(dr["Pro_Price"]),
                        Pro_Stock = Convert.ToInt32(dr["Pro_Stock"]),
                        Pro_img = Convert.ToString(dr["Pro_img"]),
                        Pro_img_name = Convert.ToString(dr["Pro_img_name"])
                    });
                }
            }
            sqlCon.Close();
            return View(GPC);
        }

        public ActionResult ProductSell(int? pro_id, Add_Order_Class AOC)
        {
            if (Session["UserEmail"] != null)
            {
                SqlConnection sqlCon = new SqlConnection(conStr);
                SqlCommand sqlCmd = new SqlCommand("SP_Add_Order", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                sqlCmd.Parameters.AddWithValue("@Product_ID", pro_id);
                sqlCmd.Parameters.AddWithValue("@Customer_ID", int.Parse(Session["UserID"].ToString()));
                sqlCmd.Parameters.AddWithValue("@Quantity", 1);
                sqlCmd.Parameters.AddWithValue("@IsActive", true);
                int result = sqlCmd.ExecuteNonQuery();
                if (result == -1)
                {
                    ViewData["message"] = "Product Ordered Successfully!";
                }
                else
                {
                    ViewData["message"] = "Product Ordered Failed!";
                }
                sqlCon.Close();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "CustomerLogin");
            }
        }
    }
}