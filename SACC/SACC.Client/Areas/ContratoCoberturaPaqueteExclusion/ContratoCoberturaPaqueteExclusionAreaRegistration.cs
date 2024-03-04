using System.Web.Mvc;

namespace SACC.Client.Areas.ContratoCoberturaPaqueteExclusion
{
    public class ContratoCoberturaPaqueteExclusionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ContratoCoberturaPaqueteExclusion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ContratoCoberturaPaqueteExclusion_default",
                "ContratoCoberturaPaqueteExclusion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
