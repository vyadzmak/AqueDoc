using System.Web;
using System.Web.Optimization;

namespace AqueDoc
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery.scoped.js",
                      //"~/Scripts/angular-filemanager/bower_components/bootstrap/dist/js/bootstrap.min.js",
                      "~/Scripts/bootstrap-dialog.min.js",
                      "~/Scripts/BootstrapMenu.min.js"
                //
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                     //"~/Scripts/angular-filemanager/bower_components/bootstrap/dist/css/bootstrap.min.css",
                      "~/Content/bootstrap-dialog.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/metisMenu.min.css",
                      "~/Content/site.css",
                      "~/Content/sb-admin-2.css",
                      "~/Content/site.css"


                      ));

            //additional byndles for project
            bundles.Add(new ScriptBundle("~/bundles/sbadmin").Include(
                     "~/Scripts/sb-admin-2.js",
                     "~/Scripts/metisMenu.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                     "~/Scripts/angular.js",
                     "~/Scripts/angular-ui-router.js",

                     "~/Scripts/angular-route.min.js",
                     "~/Scripts/angular-ui-router-title.js",
                     "~/Scripts/spin.js",
                     "~/Scripts/angular-spinner.js",
                      "~/Scripts/ui-bootstrap-tpls-2.1.3.min.js"
                //

                     ));

            bundles.Add(new ScriptBundle("~/bundles/aqueDocApp").Include(
                    "~/Scripts/app/Scripts/app.js",
                    "~/Scripts/app/Scripts/routeConfigurator.js",
                    "~/Scripts/app/Controllers/loginController.js",
                    "~/Scripts/app/Controllers/dashBoardController.js",
                    "~/Scripts/app/Controllers/inboxController.js",
                    "~/Scripts/app/Controllers/inboxDetailsController.js",
                    "~/Scripts/app/Controllers/tasksController.js",
                    "~/Scripts/app/Controllers/taskDetailsController.js"

//                    "~/Scripts/App/loginCtrl.js",
//                    "~/Scripts/App/inboxCtrl.js",
//                    "~/Scripts/App/routeConfigurator.js",
//                    "~/Scripts/App/settings.js"

                    )
                    );
        }
    }
}
