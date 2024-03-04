using System.Web.Mvc;

namespace SACC.Client.Areas.UsuarioContrato
{
    public class UsuarioContratoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "UsuarioContrato";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "UsuarioContrato_default",
                "UsuarioContrato/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
