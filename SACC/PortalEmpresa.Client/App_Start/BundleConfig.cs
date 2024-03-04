using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;
using System.Web;
using System.Web.Optimization;

namespace PortalEmpresa.Client
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Layout
            var nullBuilder = new NullBuilder();
            var nullOrderer = new NullOrderer();

            var mainCss = new Bundle("~/css/layout");
            mainCss.Transforms.Add(new CssMinify());
            mainCss.Builder = nullBuilder;
            mainCss.Orderer = nullOrderer;
            mainCss.Include(
               "~/Assets/css/Plugins/bootstrap/bootstrap.css",
               "~/Assets/css/Plugins/animate.css/animate.css",
               "~/Assets/css/Plugins/fontawesome/css/font-awesome.css",
               "~/Assets/fonts/Open-Sans/css/fonts.css",
               "~/Assets/css/Plugins/metisMenu/metisMenu.css",
               "~/Assets/css/Plugins/datepicker/datepicker.css",
               "~/Assets/sass/homer/style.min.css",
               "~/Assets/sass/ternium/style.ternium.min.css",
               "~/Assets/css/Plugins/iCheck/skins/square/green.css",
               "~/Assets/css/Plugins/sweetalert/sweet-alert.css",
               "~/Assets/css/Plugins/datepicker/bootstrap-datepicker3.css",
               "~/Assets/fonts/pe-icon-7-stroke/css/pe-icon-7-stroke.css",
               "~/Assets/fonts/pe-icon-7-stroke/css/helper.css",
               "~/Content/nova.css");
            bundles.Add(mainCss);


            bundles.Add(new ScriptBundle("~/js/layout")
               .Include(
               "~/Assets/js/Plugins/jquery/jquery.js",
               "~/Assets/js/Plugins/jquery/jquery.unobtrusive-ajax.js",
               "~/Assets/js/Plugins/validate/jquery-validate.js",
               "~/Assets/js/Plugins/bootstrap/bootstrap.js",
               "~/Assets/js/Tools/common.js",
               "~/Assets/js/Plugins/metisMenu/metisMenu.js",
               "~/Assets/js/Plugins/slimScroll/jquery.slimscroll.js",
               "~/Assets/js/homer.js",
               "~/Assets/js/Plugins/sparkline/sparkline.js",
               "~/Assets/js/Plugins/iCheck/icheck.js",
               "~/Assets/js/Plugins/sweetalert/sweet-alert.min.js",
               "~/Assets/js/Plugins/datepicker/bootstrap-datepicker.js",
               "~/Assets/js/Plugins/datepicker/locales/bootstrap-datepicker.es.min.js",
               "~/Assets/js/Plugins/bootstrapwizard/jquery-latest.js",
               "~/Assets/js/Plugins/bootstrapwizard/jquery.bootstrap.wizard.js",
               "~/Scripts/helper.js"));
            #endregion Layout

            #region DataTable Bundles
            bundles.Add(new ScriptBundle("~/js/datatables")
               .Include(
                "~/Assets/js/Plugins/bootstraptable/bootstrap-table.js",
                "~/Assets/js/Plugins/bootstraptable/locale/bootstrap-table-es-ES.js"));

            bundles.Add(new StyleBundle("~/css/datatables")
               .Include(
                "~/Assets/css/Plugins/bootstraptable/bootstrap-table.css"));
            #endregion DataTable Bundles


            #region select
            bundles.Add(new ScriptBundle("~/js/select").Include(
                "~/Assets/js/Plugins/select2/select2.min.js"));

            bundles.Add(new StyleBundle("~/css/select").Include(
                "~/Assets/css/Plugins/select2/select2.css",
                "~/Assets/css/Plugins/select2bootstrap/select2-bootstrap.css"));
            #endregion

            BundleTable.EnableOptimizations = false;
        }
    }
}