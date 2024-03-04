using System.Web.Mvc;

namespace SACC.Client.Areas.MembresiaContrato
{
    public class MembresiaContratoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MembresiaContrato";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MembresiaContrato_default",
                "MembresiaContrato/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
