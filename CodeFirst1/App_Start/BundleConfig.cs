using System.Web;
using System.Web.Optimization;

namespace CodeFirst1
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/templateJs").Include(
            //            "~/Content/Template/js/*.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/Template/css/*.css",
            //          "~/Content/Template/style.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/sitecss").Include(
                      "~/Content/custom/site.css",
                       "~/Content/PagedList.css"));
        }
    }
}
