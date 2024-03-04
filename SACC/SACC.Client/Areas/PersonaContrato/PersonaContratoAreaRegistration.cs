using System.Web.Mvc;

namespace SACC.Client.Areas.PersonaContrato
{
    public class PersonaContratoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PersonaContrato";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PersonaContrato_default",
                "PersonaContrato/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
