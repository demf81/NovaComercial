using System.Web.Mvc;

namespace SACC.Client.Areas.EmpresaArchivoTipo
{
    public class EmpresaArchivoTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EmpresaArchivoTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "EmpresaArchivoTipo_default",
                "EmpresaArchivoTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}