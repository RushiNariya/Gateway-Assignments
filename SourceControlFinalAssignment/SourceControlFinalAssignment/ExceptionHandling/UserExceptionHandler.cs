using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using log4net;

namespace SourceControlFinalAssignment.ExceptionHandling
{
    public class UserExceptionHandler : HandleErrorAttribute
    {
		//private static readonly ILog Log = LogManager.GetLogger(typeof(ProductExceptionHandler));

		public override void OnException(ExceptionContext filterContext)
		{
			if (filterContext.Exception is NullReferenceException)
			{
				//Log.Error("NullReferanceException exception occured :" + filterContext.Exception.Message);
				var controllerName = (string)filterContext.RouteData.Values["controller"];
				var actionName = (string)filterContext.RouteData.Values["action"];

				HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

				filterContext.Result = new ViewResult
				{
					ViewName = "~/Views/Shared/Error.cshtml",
					ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
				};

				filterContext.ExceptionHandled = true;
			}
			else if (filterContext.Exception is NotImplementedException)
			{
				//Log.Error("NotImplementedException exception occured :" + filterContext.Exception.Message);
				var controllerName = (string)filterContext.RouteData.Values["controller"];
				var actionName = (string)filterContext.RouteData.Values["action"];

				HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

				filterContext.Result = new ViewResult
				{
					ViewName = "~/Views/Shared/Error.cshtml",
					ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
				};

				filterContext.ExceptionHandled = true;
			}
			else if (filterContext.Exception is InvalidOperationException)
			{
				//Log.Error("InvalidOperationException exception occured :" + filterContext.Exception.Message);
				var controllerName = (string)filterContext.RouteData.Values["controller"];
				var actionName = (string)filterContext.RouteData.Values["action"];

				HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

				filterContext.Result = new ViewResult
				{
					ViewName = "~/Views/Shared/Error.cshtml",
					ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
				};

				filterContext.ExceptionHandled = true;
			}
			else if (filterContext.Exception is Exception)
			{
				//Log.Error("Exception exception occured :" + filterContext.Exception.Message);
				var controllerName = (string)filterContext.RouteData.Values["controller"];
				var actionName = (string)filterContext.RouteData.Values["action"];

				HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

				filterContext.Result = new ViewResult
				{
					ViewName = "~/Views/Shared/Error.cshtml",
					ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
				};

				filterContext.ExceptionHandled = true;
			}


			//filterContext.HttpContext.IsCustomErrorEnabled
			base.OnException(filterContext);
		}
	}
}