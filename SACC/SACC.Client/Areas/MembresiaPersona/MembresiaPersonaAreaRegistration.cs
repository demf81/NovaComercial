using System.Web.Mvc;

namespace SACC.Client.Areas.MembresiaPersona
{
    public class MembresiaPersonaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MembresiaPersona";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MembresiaPersona_default",
                "MembresiaPersona/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
