using System.Web.Mvc;

namespace SACC.Client.Areas.EmpresaDocumento
{
    public class EmpresaDocumentoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EmpresaDocumento";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "EmpresaDocumento_default",
                "EmpresaDocumento/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
