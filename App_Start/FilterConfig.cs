using System.Web;
using System.Web.Mvc;

namespace SohelAfzalShajol_Playon24
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
