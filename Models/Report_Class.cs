using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SohelAfzalShajol_Playon24.Models
{
    public class Report_Class<Tmp>
    {
        public string RptFileName { get; set; }
        public string RptTitle { get; set; }
        public string ReportTitle { get; set; }
        public List<Tmp> DataSource { get; set; }
        public bool IsPassParamToCr { get; set; }
    }
}