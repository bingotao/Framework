
using React;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace JXGIS.Framework.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var babelTransForm = new IBundleTransform[] { new BabelTransform(), new JsMinify() };
            var lessPattern = "*.less";
            var jsPattern = "*.js";
            var jsxPattern = "*.jsx";
            // 全局样式
            bundles.Add(new LessBundle("~/g/css").IncludeDirectory("~/Extends/GlobalStyles", lessPattern, true));
            // 全局js
            bundles.Add(new ScriptBundle("~/g/js").IncludeDirectory("~/Extends/CommonJS", jsPattern, true));

            // Component js,css 打包
            var path = System.Web.HttpContext.Current.Server.MapPath("~/Extends/Components");
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] dirs = di.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                var fileName = dir.Name;
                bundles.Add(new Bundle(string.Format("~/{0}/js", fileName)).IncludeDirectory("~/Extends/Components/" + fileName, jsxPattern, true));
                bundles.Add(new LessBundle(string.Format("~/{0}/css", fileName)).IncludeDirectory("~/Extends/Components/" + fileName, lessPattern, true));
            }
        }
    }

    public class BabelTransform : IBundleTransform
    {
        /// <summary>
        /// Transforms the content in the <see cref="T:System.Web.Optimization.BundleResponse" /> object.
        /// </summary>
        /// <param name="context">The bundle context.</param>
        /// <param name="response">The bundle response.</param>
        public void Process(BundleContext context, BundleResponse response)
        {
            var environment = ReactEnvironment.Current;
            response.Content = environment.Babel.Transform(response.Content);
        }
    }
}