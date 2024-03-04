using System.Web.Mvc;

namespace SACC.Client.Areas.Membresia
{
    public class MembresiaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Membresia";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Membresia_default",
                "Membresia/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
