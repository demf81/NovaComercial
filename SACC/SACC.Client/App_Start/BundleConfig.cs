using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.Optimization;

namespace SACC.Client
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
               "~/Assets/css/Plugins/metisMenu/metisMenu.css",
               "~/Assets/css/Plugins/datepicker/datepicker.css",
               "~/Assets/sass/homer/style.min.css",
               "~/Assets/sass/ternium/style.ternium.min.css",
               "~/Assets/css/Plugins/iCheck/skins/square/green.css",
               "~/Assets/css/Plugins/bootstrap-touchspin/bootstrap-touchspin.min.css",
               "~/Assets/css/Plugins/datepicker/bootstrap-datepicker3.css",
               "~/Content/nova.css"
            );
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
                   "~/Assets/js/Plugins/bootstrap-touchspin/bootstrap-touchspin.min.js",
                   "~/Assets/js/Plugins/datepicker/locales/bootstrap-datepicker.es.min.js",
                   "~/Assets/js/Plugins/datepicker/bootstrap-datepicker.js",
                   "~/Assets/js/Plugins/bootstrapwizard/jquery-latest.js",
                   "~/Assets/js/Plugins/bootstrapwizard/jquery.bootstrap.wizard.js",
                   "~/Scripts/helper.js",
                   "~/Scripts/vue.min.js",
                   "~/Scripts/validaCURP.js",
                   "~/Assets/js/Plugins/jquerycookie/jquery.cookie.js"
               )
            );
            #endregion Layout


            #region SWEET ALERT
            bundles.Add(new StyleBundle("~/css/sweetalert")
                .Include(
                "~/Assets/css/Plugins/sweetalert2/sweetalert2.css")
            );

            bundles.Add(new ScriptBundle("~/js/sweetalert")
                .Include(
                    "~/Assets/js/Plugins/sweetalert2/sweetalert2.js"
                )
            );
            #endregion


            #region FONTS
            bundles.Add(new StyleBundle("~/css/fonts")
                .Include(
                    "~/Assets/css/Plugins/fontawesome/css/font-awesome.css",
                    "~/Assets/fonts/Open-Sans/css/fonts.css",
                    "~/Assets/fonts/pe-icon-7-stroke/css/pe-icon-7-stroke.css",
                    "~/Assets/fonts/pe-icon-7-stroke/css/helper.css",
                    "~/Assets/fonts/glyphicons/css/bootstrap-glyphicons.css"
                )
            );
            #endregion


            #region BOOTSTRAP TABLE
            bundles.Add(new ScriptBundle("~/js/datatables")
                .Include(
                    "~/Assets/js/Plugins/bootstraptable/bootstrap-table.js",
                    "~/Assets/js/Plugins/bootstraptable/locale/bootstrap-table-es-MX.js",
                    "~/Assets/js/Plugins/bootstraptable/extensions/editable/bootstrap-table-editable.js",
                    "~/Assets/js/Plugins/bootstraptable/extensions/editable/bootstrap-editable.js"
                )
            );

            bundles.Add(new StyleBundle("~/css/datatables")
                .Include(
                    "~/Assets/css/Plugins/bootstraptable/bootstrap-table.css",
                    "~/Assets/css/Plugins/bootstraptable/extensions/editable/bootstrap-editable.css"
                )
            );
            #endregion DataTable Bundles


            #region BOOTSTRAP SWITCH
            bundles.Add(new ScriptBundle("~/js/switch")
                .Include(
                    "~/Assets/js/Plugins/bootstrap-switch-button/bootstrap4-toggle.min.js"
                )
            );

            bundles.Add(new StyleBundle("~/css/switch")
                .Include(
                    "~/Assets/css/Plugins/bootstrap-switch-button/bootstrap4-toggle.min.css"
                )
            );
            #endregion


            #region SELECT2
            bundles.Add(new ScriptBundle("~/js/select")
                .Include(
                    "~/Assets/js/Plugins/select2/select2.min.js"
                )
            );

            bundles.Add(new StyleBundle("~/css/select")
                .Include(
                    "~/Assets/css/Plugins/select2/select2.css",
                    "~/Assets/css/Plugins/select2bootstrap/select2-bootstrap.css"
                )
            );
            #endregion


            #region LADDA
            bundles.Add(new ScriptBundle("~/js/ladda")
                .Include(
                    "~/Assets/js/Plugins/ladda/spin.min.js",
                    "~/Assets/js/Plugins/ladda/ladda.min.js",
                    "~/Assets/js/Plugins/ladda/ladda.jquery.min.js"
                )
            );

            bundles.Add(new StyleBundle("~/css/ladda")
                .Include(
                    "~/Assets/css/Plugins/ladda/ladda-themeless.min.css"
                )
            );
            #endregion


            #region HELPER
            bundles.Add(new ScriptBundle("~/js/helper")
                .Include(
                    "~/Scripts/helper.alert.js",
                    "~/Scripts/constant.js",
                    "~/Scripts/helper.ajax.js",
                    //"~/Scripts/helper.grid.js",
                    //"~/Scripts/helper.var.js",
                    "~/Scripts/combo.js",
                    "~/Scripts/common.js"
                )
            );
            #endregion


            #region CTRL USER PERSONA
            bundles.Add(new ScriptBundle("~/js/CtrlUserPersona")
                .Include(
                    "~/Scripts/Areas/Persona/CtrlUserPersona.js"
                )
            );
            #endregion


            #region CTRL USER COBERTURA POR CONTRATO
            bundles.Add(new ScriptBundle("~/js/CtrlUserContratoCobertura")
                .Include(
                    "~/Scripts/Areas/ContratoCobertura/CtrlUserContratoCobertura.js"
                )
            );
            #endregion


            BundleTable.EnableOptimizations = false;
        }
    }
}