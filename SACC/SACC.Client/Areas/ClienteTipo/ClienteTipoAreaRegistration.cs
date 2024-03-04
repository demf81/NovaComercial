using System.Web.Mvc;

namespace SACC.Client.Areas.ClienteTipo
{
    public class ClienteTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ClienteTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ClienteTipo_default",
                "ClienteTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
