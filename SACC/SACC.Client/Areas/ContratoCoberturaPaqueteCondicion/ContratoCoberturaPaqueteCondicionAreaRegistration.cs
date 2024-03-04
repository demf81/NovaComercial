using System.Web.Mvc;

namespace SACC.Client.Areas.ContratoCoberturaPaqueteCondicion
{
    public class ContratoCoberturaPaqueteCondicionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ContratoCoberturaPaqueteCondicion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ContratoCoberturaPaqueteCondicion_default",
                "ContratoCoberturaPaqueteCondicion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
