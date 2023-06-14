using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using SohelAfzalShajol_Playon24.Models;

namespace SohelAfzalShajol_Playon24.Controllers
{
    public class CustomerLoginController : Controller
    {
        // GET: CustomerLogin
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Cus_Login_Class CLC)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conStr);
            SqlCommand sqlCmd = new SqlCommand("SP_Customer_Login", sqlCon);
            sqlCon.Open();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Cus_Email", CLC.Cus_Email);
            sqlCmd.Parameters.AddWithValue("@Cus_Password", CLC.Cus_Password);
            SqlDataReader sqlDrd = sqlCmd.ExecuteReader();
            if (sqlDrd.Read())
            {
                FormsAuthentication.SetAuthCookie(CLC.Cus_Email, true);
                HttpCookie cookie = new HttpCookie("Playon24");
                if (CLC.RememberMe == true)
                {
                    cookie["Email"] = CLC.Cus_Email;
                    cookie["Password"] = CLC.Cus_Password;
                    cookie.Expires = DateTime.Now.AddDays(2);
                    HttpContext.Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Response.Cookies.Add(cookie);
                }
                Session["UserEmail"] = CLC.Cus_Email.ToString();
                Session["UserID"] = Convert.ToString(sqlDrd.GetInt32(0));
                Session["UserName"] = sqlDrd.GetString(1);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewData["message"] = "Login Failed! Please Try Again";
            }
            sqlCon.Close();
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "CustomerLogin");
        }
    }
}