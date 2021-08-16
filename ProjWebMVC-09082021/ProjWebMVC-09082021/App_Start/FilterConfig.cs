using System.Web;
using System.Web.Mvc;

namespace ProjWebMVC_09082021
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
