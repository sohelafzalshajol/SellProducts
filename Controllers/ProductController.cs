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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Product_Class PDC, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string filename = Path.GetFileName(file.FileName);
                string newFileName = DateTime.Now.ToString("yymmssfff") + filename;
                string extntion = Path.GetExtension(file.FileName);
                if ((extntion.ToLower() == ".jpg" || extntion.ToLower() == ".jpeg" || extntion.ToLower() == ".png") && file.ContentLength <= 10000000)
                {
                    string imgPath = Path.Combine(Server.MapPath("~/images/"), newFileName);
                    string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlConnection sqlCon = new SqlConnection(conStr);
                    SqlCommand sqlCmd = new SqlCommand("SP_CRUD_Product", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCon.Open();
                    sqlCmd.Parameters.AddWithValue("@Action", int.Parse((PDC.Action = 1).ToString()));
                    sqlCmd.Parameters.AddWithValue("@Product_ID", int.Parse((PDC.Product_ID = 0).ToString()));
                    sqlCmd.Parameters.AddWithValue("@Product_Name", PDC.Product_Name);
                    sqlCmd.Parameters.AddWithValue("@Pro_Description", PDC.Pro_Description);
                    sqlCmd.Parameters.AddWithValue("@Pro_Category", PDC.Pro_Category);
                    sqlCmd.Parameters.AddWithValue("@Pro_Price", float.Parse(PDC.Pro_Price.ToString()));
                    sqlCmd.Parameters.AddWithValue("@Pro_Stock", int.Parse(PDC.Pro_Stock.ToString()));
                    sqlCmd.Parameters.AddWithValue("@Pro_img", imgPath);
                    sqlCmd.Parameters.AddWithValue("@Pro_img_name", newFileName);
                    sqlCmd.Parameters.AddWithValue("@EntryBy", int.Parse(Session["UserID"].ToString()));
                    sqlCmd.Parameters.AddWithValue("@IsActive", PDC.IsActive);
                    int result = sqlCmd.ExecuteNonQuery();
                    if (result == -1)
                    {
                        file.SaveAs(imgPath);
                        ViewData["message"] = "Product Added Successfully!";
                    }
                    else
                    {
                        ViewData["message"] = "Product Addition Failed!";
                    }
                    sqlCon.Close();
                }
                else
                {
                    ViewData["message"] = "Image file is not valid!";
                }
            }
            return RedirectToAction("Index");
        }
    }
}