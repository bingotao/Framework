﻿using JXGIS.Framework.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXGIS.Framework.Web
{
    public class ConfigActionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var viewBag = filterContext.Controller.ViewBag;
                viewBag.Title = SystemUtils.Config.Title.ToString();
                viewBag.BaseUrl = SystemUtils.BaseUrl;
                viewBag.Favicon = SystemUtils.Config.Favicon.ToString();
                viewBag.Description = SystemUtils.Config.Description.ToString();
                viewBag.Keywords = SystemUtils.Config.Keywords.ToString();
            }
            catch
            {

            }
        }
    }
}