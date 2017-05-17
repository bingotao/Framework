using JXGIS.Framework.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXGIS.Framework.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //自定义过滤器
            filters.Add(new CustomerHandleError());
            filters.Add(new ConfigActionFilter());
        }
    }
}