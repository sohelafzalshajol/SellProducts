using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SohelAfzalShajol_Playon24.Models;
using System.Net.Http;

namespace SohelAfzalShajol_Playon24.Controllers
{
    public class CustomerRegController : Controller
    {
        // GET: CustomerReg
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Cus_Reg_Class CRC)
        {
            if (ModelState.IsValid)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:64013/api/CusReg");

                var addCus = hc.PostAsJsonAsync<Cus_Reg_Class>("CusReg", CRC);
                addCus.Wait();

                var saveData = addCus.Result;
                if (saveData.IsSuccessStatusCode)
                {
                    ViewBag.message = "The customer " + CRC.Customer_Name + " is registered successfully!";
                }
            }
            return View();
        }
    }
}