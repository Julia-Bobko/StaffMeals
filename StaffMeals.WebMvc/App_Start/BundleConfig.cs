using System.Web;
using System.Web.Optimization;

namespace IDB.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();







            //bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
            //    "~/Scripts/kendo/kendo.all.*",
            //    "~/Scripts/kendo/kendo.aspnetmvc.*"
            //    ));

            //bundles.Add(new ScriptBundle("~/bundles/kendo/cultures").Include(
            //    "~/Scripts/kendo/cultures/kendo.culture.fr.min.js",
            //    "~/Scripts/kendo/cultures/kendo.culture.zh.min.js"));

            /////////////////////////////
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
            "~/Scripts/kendo/kendo.all.min.js",
                // "~/Scripts/kendo/kendo.timezones.min.js", // uncomment if using the Scheduler
            "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
            "~/Content/kendo/kendo.common.min.css",
            "~/Content/kendo/kendo.default.min.css"));

        }

        
    }
}
