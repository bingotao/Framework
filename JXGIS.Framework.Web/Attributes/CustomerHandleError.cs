using JXGIS.Framework.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXGIS.Framework.Web.Attributes
{
    public class CustomerHandleError : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is CustomerException)
            {
                if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled) return;
                base.OnException(filterContext);
                filterContext.Result = new JsonResult() { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new ReturnObject(filterContext.Exception.Message) };
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            }
        }
    }
}