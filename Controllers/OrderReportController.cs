using Microsoft.Practices.EnterpriseLibrary.Data;
using SohelAfzalShajol_Playon24.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace SohelAfzalShajol_Playon24.Controllers
{
    public class OrderReportController : Controller
    {
        // GET: OrderReport
        public ActionResult Index()
        {
            return View();
        }
        
        public void GenerateOrderReport()
        {
            Report_Class<OrderInfoClass> objReportCls = new Report_Class<OrderInfoClass>();
            objReportCls.DataSource = GetAllOrderInfo();
            objReportCls.RptTitle = "Order Informations Report";
            objReportCls.RptFileName = "OrderReport.rpt";
            this.HttpContext.Session["ReportType"] = "OrderReport";
            this.HttpContext.Session["ReportParam"] = objReportCls;
        }

        public List<OrderInfoClass> GetAllOrderInfo()
        {
            //string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            
            


            DataTable dt = new DataTable();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("DefaultConnection");
            //Database db = factory.CreateDefault();
            //Database db = DatabaseFactory.CreateDatabase("DefaultConnection");
            DbCommand dbCmd = db.GetStoredProcCommand("SP_Get_OrderInfo");
            db.AddInParameter(dbCmd, "Customer_ID", DbType.Int32, int.Parse(Session["UserID"].ToString()));
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            var list = ConvertDataTableToList<OrderInfoClass>(dt);
            return list;
        }

        private static List<Tmp> ConvertDataTableToList<Tmp>(DataTable dt)
        {
            List<Tmp> data = new List<Tmp>();
            foreach (DataRow row in dt.Rows)
            {
                Tmp item = GetItem<Tmp>(row);
                data.Add(item);
            }
            return data;
        }

        private static Tmp GetItem<Tmp>(DataRow dr) {
            Type temp = typeof(Tmp);
            Tmp obj = Activator.CreateInstance<Tmp>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return obj;
        }
    }
}