using System.Web;
using System.Web.Mvc;

namespace DemoWebAPIDemo___Eduardo_M
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
