﻿using System.Web;
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
                "~/Scripts/vendor/custom/owl.carousel.min.js",
                "~/Scripts/vendor/custom/moment-with-locales.min.js",
                "~/Scripts/vendor/custom/Chart.min.js",
                "~/Scripts/vendor/custom/hideMaxListItem.js",
                "~/Scripts/vendor/boostrap/bootstrap-datetimepicker.min.js",
                "~/Scripts/vendor/jquery/jquery.matchHeight-min.js",
                "~/Scripts/vendor/jquery/jquery.fs.scroller.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-slider.min.css",
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
                "~/Content/ngDialog/ngDialog.css",
                "~/Content/ngDialog/ngDialog-theme-default.min.css",
                "~/Content/angular-toast/angular-toastr.min.css",
                "~/Content/angular-busy/angular-busy.min.css",
                "~/Content/angular-flash/angular-flash.min.css",
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
                "~/Scripts/vendor/custom/ui-carousel.min.js",
                "~/Scripts/vendor/custom/ngDialog.min.js",
                "~/Scripts/vendor/custom/angular-flash.min.js",
                "~/Scripts/vendor/custom/angular-busy.min.js"));


            // Angular Bundle

            //const string ANGULAR_APP_ROOT = "~/Scripts/app";
            //const string VIRTUAL_BUNDLE_PATH = ANGULAR_APP_ROOT + "main.js";

            //var scriptBundle = new ScriptBundle(VIRTUAL_BUNDLE_PATH)
            //    .Include(ANGULAR_APP_ROOT + "app.js")
            //    .IncludeDirectory(ANGULAR_APP_ROOT, "*.js", searchSubdirectories: true);

            //bundles.Add(scriptBundle);


            bundles.Add(new ScriptBundle("~/bundles/app/main")
                .Include("~/Scripts/app/app.js",
                    "~/Scripts/app/app-routes.js")
                    .IncludeDirectory("~/Scripts/app/shared/directives", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/shared/factories", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/account", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/Evaluation", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/history", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/privateProfile", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/publicProfile", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/search", "*.js").WithLastModifiedToken()
                    .IncludeDirectory("~/Scripts/app/components/index", "*.js").WithLastModifiedToken()
                    );
            //
        }
    }
}
