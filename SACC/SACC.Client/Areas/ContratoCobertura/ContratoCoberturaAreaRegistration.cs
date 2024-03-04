using System.Web.Mvc;

namespace SACC.Client.Areas.ContratoCobertura
{
    public class ContratoCoberturaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ContratoCobertura";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ContratoCobertura_default",
                "ContratoCobertura/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
