using System.Web.Mvc;

namespace SACC.Client.Areas.Persona
{
    public class PersonaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Persona";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Persona_default",
                "Persona/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
