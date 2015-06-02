using System.Web;
using System.Web.Optimization;

namespace TodoUi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                    "~/Scripts/jquery-1.10.2.js",
                    "~/Scripts/lodash.js",
                    "~/Scripts/backbone.js",
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/App/styles/app.css"));
        }
    }
}
