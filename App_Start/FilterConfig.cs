using System.Web;
using System.Web.Mvc;

namespace ASPNETWEBAPI_AUTH_Manually_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
