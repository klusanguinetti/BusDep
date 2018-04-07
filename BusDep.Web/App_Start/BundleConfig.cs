using System.Web.Optimization;

namespace BusDep.Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/vendor/jquery/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/vendor/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/vendor/boostrap/bootstrap.js",
                "~/Scripts/vendor/boostrap/bootstrap-slider.min.js",
                "~/Scripts/vendor/custom/please-wait.min.js",
                "~/Scripts/vendor/custom/moment-with-locales.min.js",
                "~/Scripts/vendor/custom/Chart.min.js",
                "~/Scripts/vendor/custom/hideMaxListItem.js",
                "~/Scripts/vendor/boostrap/bootstrap-datetimepicker.min.js",
                "~/Scripts/vendor/jquery/jquery.matchHeight-min.js",
                "~/Scripts/vendor/jquery/jquery.fs.scroller.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/Content/bootstrap-slider.min.css",
                "~/Content/please-wait.css",
                "~/Content/jquery.fs.scroller.css",
                "~/Content/jquery.fs.selecter.css",
                "~/Content/loading-bar.min.css",
                "~/Content/country-flags-icon.css",
                "~/Content/bootstrap-datetimepicker.css",
                "~/Content/club-flags-icon.css",
                "~/Content/puestos-flags-icon.css",
                "~/Content/ngDialog/ngDialog.css",
                "~/Content/ngDialog/ngDialog-theme-default.min.css",
                "~/Content/angular-toast/angular-toastr.min.css",
                "~/Content/angular-busy/angular-busy.min.css",
                "~/Content/angular-flash/angular-flash.min.css",
                "~/Content/ui-cropper.css",
                "~/Content/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/vendor/angular/angular.min.js",
                "~/Scripts/vendor/angular/angular-route.js",
                "~/Scripts/vendor/angular/angular-messages.js",
                "~/Scripts/vendor/angular/angular-animate.min.js",
                "~/Scripts/vendor/angular/angular-local-storage.min.js",
                "~/Scripts/vendor/angular/angular-promise-buttons.min.js",
                "~/Scripts/vendor/angular/angular-toastr.min.js",
                "~/Scripts/vendor/angular/angular-toastr.tpls.min.js",
                "~/Scripts/vendor/angular/angular-chart.min.js",
                "~/Scripts/vendor/custom/loading-bar.min.js",
                "~/Scripts/vendor/custom/ngDialog.min.js",
                "~/Scripts/vendor/custom/angular-flash.min.js",
                "~/Scripts/vendor/custom/angular-busy.min.js",
                "~/Scripts/vendor/custom/ng-file-upload.min.js",
                "~/Scripts/vendor/custom/ui-bootstrap-tpls.min.js",
                "~/Scripts/vendor/custom/ng-file-upload-shim.min.js",
                "~/Scripts/vendor/custom/ui-cropper.js"));

            bundles.Add(new ScriptBundle("~/bundles/app/main")
                .Include("~/Scripts/app/app.js", "~/Scripts/app/app-routes.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/shared/components/headerProfile", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/shared/directives", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/shared/factories", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/Account", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/Analyst", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/Coach", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/Common", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/Evaluation", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/Profile", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/Search", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/BackOffice/Abm", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/Evento", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/BackOffice/Jugador", "*.js").WithLastModifiedToken()
                    );

        }
    }
}
