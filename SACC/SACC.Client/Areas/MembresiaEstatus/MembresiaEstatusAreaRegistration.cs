using System.Web.Mvc;

namespace SACC.Client.Areas.MembresiaEstatus
{
    public class MembresiaEstatusAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MembresiaEstatus";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MembresiaEstatus_default",
                "MembresiaEstatus/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
