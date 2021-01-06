using System.Web;
using System.Web.Mvc;
using ProductManagement.ExceptionHandling;

namespace ProductManagement
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ProductExceptionHandler());
            //filters.Add(new HandleErrorAttribute());
        }
    }
}
