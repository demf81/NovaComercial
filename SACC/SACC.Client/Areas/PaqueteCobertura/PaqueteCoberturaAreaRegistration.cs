using System.Web.Mvc;

namespace SACC.Client.Areas.PaqueteCobertura
{
    public class PaqueteCoberturaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PaqueteCobertura";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PaqueteCobertura_default",
                "PaqueteCobertura/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
