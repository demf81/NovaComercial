using System.Web.Mvc;

namespace SACC.Client.Areas.EmpresaDocumentoTipo
{
    public class EmpresaDocumentoTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EmpresaDocumentoTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "EmpresaDocumentoTipo_default",
                "EmpresaDocumentoTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
