using Cassette;
using Cassette.Scripts;
using Cassette.Stylesheets;

namespace JXGIS.Framework.Web
{
    /// <summary>
    /// Configures the Cassette asset bundles for the web application.
    /// </summary>
    public class CassetteBundleConfiguration : IConfiguration<BundleCollection>
    {
        public void Configure(BundleCollection bundles)
        {
#if !DEBUG
            var jsPattern = "*.js;*.jsx";
            var cssPattern = "*.css;*.less";

            // 全局样式
            bundles.Add<StylesheetBundle>("g.css",
                "Extends/GlobalStyles/global.less",
                "Extends/GlobalStyles/iconfont.less");

            // 全局js
            bundles.AddPerSubDirectory<ScriptBundle>("Extends/CommonJS", new FileSearch() { SearchOption = System.IO.SearchOption.AllDirectories, Pattern = jsPattern });
            // 组件
            bundles.AddPerSubDirectory<StylesheetBundle>("Extends/Components", new FileSearch() { SearchOption = System.IO.SearchOption.AllDirectories, Pattern = cssPattern });
            bundles.AddPerSubDirectory<ScriptBundle>("Extends/Components", new FileSearch() { SearchOption = System.IO.SearchOption.AllDirectories, Pattern = jsPattern });
#endif
        }
    }
}