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

            // ȫ����ʽ
            bundles.Add<StylesheetBundle>("g.css",
                "Extends/GlobalStyles/global.less",
                "Extends/GlobalStyles/iconfont.less");

            // ȫ��js
            bundles.AddPerSubDirectory<ScriptBundle>("Extends/CommonJS", new FileSearch() { SearchOption = System.IO.SearchOption.AllDirectories, Pattern = jsPattern });
            // ���
            bundles.AddPerSubDirectory<StylesheetBundle>("Extends/Components", new FileSearch() { SearchOption = System.IO.SearchOption.AllDirectories, Pattern = cssPattern });
            bundles.AddPerSubDirectory<ScriptBundle>("Extends/Components", new FileSearch() { SearchOption = System.IO.SearchOption.AllDirectories, Pattern = jsPattern });
#endif
        }
    }
}