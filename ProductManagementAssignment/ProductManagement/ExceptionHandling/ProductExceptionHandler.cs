using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Exceptions;
using log4net;

namespace ProductManagement.ExceptionHandling
{
	//Handling Exceptions Here
    public class ProductExceptionHandler: HandleErrorAttribute
    {
		private static readonly ILog Log = LogManager.GetLogger(typeof(ProductExceptionHandler));

		public override void OnException(ExceptionContext filterContext)
		{
			//Handling NullReferenceException
			if (filterContext.Exception is NullReferenceException)
			{
				Log.Error("NullReferanceException exception occured :" + filterContext.Exception.Message);
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
			//Handling OverflowException
			else if (filterContext.Exception is OverflowException)
			{
				Log.Error("OverflowException exception occured :" + filterContext.Exception.Message);
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
			//Handling InvalidCastException
			else if (filterContext.Exception is InvalidCastException)
			{
				Log.Error("InvalidCastException exception occured :" + filterContext.Exception.Message);
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
			//Handling InvalidOperationException
			else if (filterContext.Exception is InvalidOperationException)
			{
				Log.Error("InvalidOperationException exception occured :" + filterContext.Exception.Message);
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
			//Handling NotImplementedException
			else if (filterContext.Exception is NotImplementedException)
			{
				Log.Error("NotImplementedException exception occured :" + filterContext.Exception.Message);
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
			//Handling HttpException
			else if (filterContext.Exception is HttpException)
			{
				Log.Error("HttpException exception occured :" + filterContext.Exception.Message);
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
			//Handling TimeoutException
			else if (filterContext.Exception is TimeoutException)
			{
				Log.Error("TimeoutException exception occured :" + filterContext.Exception.Message);
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
			//Handling ProductNotFoundException, a User Defined Exception
			else if (filterContext.Exception is ProductNotFoundException)
			{
				Log.Error("ProductNotFoundException exception occured :" + filterContext.Exception.Message);
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
			// Handling rest of all Exceptions
			else if (filterContext.Exception is Exception)
			{
				Log.Error("Exception exception occured :" + filterContext.Exception.Message);
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

			base.OnException(filterContext);
		}
	}
}