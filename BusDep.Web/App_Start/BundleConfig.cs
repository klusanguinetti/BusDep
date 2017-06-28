using System.Web;
using System.Web.Optimization;

namespace BusDep.Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-material.js",
                "~/Scripts/angular-animate.min.js",
                "~/Scripts/angular-aria.min.js",
                "~/Scripts/angular-messages.min.js",
                "~/Scripts/angular-route.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/app/appBusDep.js")
                //       .IncludeDirectory("~/Scripts/app/Common", "*.js")
                //.IncludeDirectory("~/Scripts/app/Directives", "*.js")
                .IncludeDirectory("~/Scripts/app/Controllers", "*.js")
                .IncludeDirectory("~/Scripts/app/Services", "*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/main.css"));
        }
    }
}
