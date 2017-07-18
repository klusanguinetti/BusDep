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
                        "~/Scripts/vendor/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/vendor/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/vendor/bootstrap.js",
                      "~/Scripts/vendor/please-wait.min.js",
                      "~/Scripts/vendor/owl.carousel.min.js",
                      "~/Scripts/vendor/moment.min.js",
                      "~/Scripts/vendor/bootstrap-datetimepicker.min.js",
                      "~/Scripts/vendor/jquery.matchHeight-min.js",
                      "~/Scripts/vendor/hideMaxListItem.js",
                      "~/Scripts/vendor/jquery.fs.scroller.js",
                      "~/Scripts/vendor/jquery.fs.selecter.js",
                      "~/Scripts/vendor/jquery.fs.selecter.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/owl.theme.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/please-wait.css",
                      "~/Content/jquery.fs.scroller.css",
                      "~/Content/jquery.fs.selecter.css",
                      "~/Content/loading-bar.min.css",
                      "~/Content/country-flags-icon.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/club-flags-icon.css",
                      "~/Content/ui-carousel.min.css",
                      "~/Content/style.css").WithLastModifiedToken());

            // Angular Bundle

            const string ANGULAR_APP_ROOT = "~/Scripts/app";
            const string VIRTUAL_BUNDLE_PATH = ANGULAR_APP_ROOT + "main.js";

            var scriptBundle = new ScriptBundle(VIRTUAL_BUNDLE_PATH)
                .Include(ANGULAR_APP_ROOT + "app.js")
                .IncludeDirectory(ANGULAR_APP_ROOT, "*.js", searchSubdirectories: true).WithLastModifiedToken();

            bundles.Add(scriptBundle);

        }
    }
}
