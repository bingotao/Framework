using JXGIS.Framework.BaseLib;
using JXGIS.Framework.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXGIS.Framework.Web
{
    public class Authorize : AuthorizeAttribute
    {
        /// <summary>
        /// 重写自定义授权检查
        /// </summary>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return true;
        }

        /// <summary>
        /// 重写未授权的 HTTP 请求处理
        /// </summary>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var attributes = filterContext.ActionDescriptor.GetCustomAttributes(false);
            if (attributes.Any(p => p is Data))
            {
                var jsonResult = new JsonResult();
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                jsonResult.Data = new ReturnObject("未授权，请登录获取授权后重新尝试！");
                filterContext.Result = jsonResult;
            }
            else if (attributes.Any(p => p is Page))
            {
                var url = filterContext.HttpContext.Request.Url;
                filterContext.Result = new RedirectResult(SystemUtils.LoginPageUrl);
            }
        }
    }
}