using System.Web;
using System.Web.Optimization;

namespace MountainBikeShop.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/unobtrusive-ajax").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/q").Include(
                "~/Scripts/q.js"));
            bundles.Add(new ScriptBundle("~/bundles/requester").Include(
                "~/Scripts/requester.js"));

            bundles.Add(new ScriptBundle("~/bundles/loadAllForkAdds").Include(
                "~/Scripts/loadAllForkAdds.js"));
            bundles.Add(new ScriptBundle("~/bundles/notify").Include(
                "~/Scripts/notify.js"));

            bundles.Add(new ScriptBundle("~/bundles/loadAllFrameAdds").Include(
                "~/Scripts/loadAllFrameAdds.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css")
                      .Include("~/Content/newAddStyle.css")
                      .Include("~/Content/addByIdStyle.css")
                      .Include("~/Content/addsContainer.css")
                      .Include("~/Content/searchSideBar.css")
                      .Include("~/Content/myAddsStyle.css")
                      .Include("~/Content/sliderStyle.css")
                      .Include("~/Content/errorMessageStyle.css")
                      .Include("~/Content/contactAndAboutStyle.css"));
                      
        }
    }
}
