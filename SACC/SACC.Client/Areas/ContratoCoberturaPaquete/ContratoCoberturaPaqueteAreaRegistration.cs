using System.Web.Mvc;

namespace SACC.Client.Areas.ContratoCoberturaPaquete
{
    public class ContratoCoberturaPaqueteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ContratoCoberturaPaquete";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ContratoCoberturaPaquete_default",
                "ContratoCoberturaPaquete/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
