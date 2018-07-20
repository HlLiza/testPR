using System.Web.Optimization;

namespace RentalHousingService.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/JS/jquery.js",
                      "~/Scripts/JS/jquery-migrate-1.1.1.js",
                      "~/Scripts/JS/script.js",
                      "~/Scripts/JS/superfish.js",
                      "~/Scripts/JS/jquery.equalheights.js",
                      "~/Scripts/JS/jquery.mobilemenu.js",
                      "~/Scripts/JS/jquery.easing.1.3.js",
                      "~/Scripts/JS/tmStickUp.js",
                      "~/Scripts/JS/jquery.ui.totop.js",
                      "~/Scripts/JS/owl.carousel.js",
                      "~/Scripts/JS/camera.js",
                      "~/Scripts/JS/html5shiv.js",

                      "~/Scripts/JS/jquery.mobile.customized.min.js",
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/CSS/camera.css",
                      "~/Content/CSS/owl.carousel.css",
                      "~/Content/CSS/stuck.css",
                       "~/Content/CSS/ie.css",
                      "~/Content/CSS/style.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
