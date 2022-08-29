using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        private void Log(string msg, ControllerContext filterContext)
        {
            Debug.WriteLine(String.Format("Currently executing the action filter - {0}",msg));
            Debug.WriteLine(filterContext.HttpContext.Request.RawUrl);
            Debug.Write(filterContext.Controller.ControllerContext.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("On Action Executed phase --------", filterContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("On Action Executing phase --------", filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("On Result Executed phase --------", filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("On Result Executing phase --------", filterContext);
        }
    }
}