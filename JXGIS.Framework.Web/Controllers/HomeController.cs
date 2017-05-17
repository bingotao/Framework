using JXGIS.Framework.BaseLib;
using JXGIS.Framework.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXGIS.Framework.Web.Controllers
{
    [@Authorize]
    public class HomeController : Controller
    {
        [Page]
        public ActionResult Index()
        {
            return View();
        }
        //[@HandleError]
        [Data]
        public ActionResult GetData()
        {
            throw new CustomerException("报错了");
            return Content("hahah");
        }
    }
}