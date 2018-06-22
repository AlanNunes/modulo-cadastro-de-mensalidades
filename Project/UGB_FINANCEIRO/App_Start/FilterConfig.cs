using System.Web;
using System.Web.Mvc;

namespace UGB_FINANCEIRO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
