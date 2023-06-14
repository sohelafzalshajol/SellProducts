using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SohelAfzalShajol_Playon24.Models;

namespace SohelAfzalShajol_Playon24.Controllers
{
    public class CusRegController : ApiController
    {
        public IHttpActionResult AddCustomer(Customer_Register CusReg)
        {
            SohelAfzalShajol_Playon24Entities db = new SohelAfzalShajol_Playon24Entities();
            db.SP_Customer_Register(CusReg.Customer_Name, CusReg.Cus_Email, CusReg.Cus_Gender, CusReg.Cus_Type, CusReg.Cus_Password, CusReg.Cus_RePassword, CusReg.IsActive);
            db.SaveChanges();
            return Ok();
        }
    }
}