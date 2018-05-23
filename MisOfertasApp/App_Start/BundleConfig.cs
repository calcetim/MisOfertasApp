using System.Web;
using System.Web.Optimization;

namespace MisOfertasApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.custom.css",
                      "~/Content/smoke.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/smoke.min.js",
                      "~/Scripts/lang/es.js",
                      "~/Scripts/jquery.Rut.js",
                      "~/Scripts/angular.js",
                      "~/Scripts/spin.min.js",
                      "~/Scripts/angular-spinner.min.js",
                      "~/Scripts/angular-loading-spinner.js",
                      "~/AppMisOfertaNg/app/app.js",
                      "~/AppMisOfertaNg/app/controller/RegistroController.js",
                      "~/AppMisOfertaNg/app/controller/LoginController.js",
                      "~/AppMisOfertaNg/app/controller/PublicarController.js",
                      "~/Scripts/global.js"
                      ));


        }
    }
}
