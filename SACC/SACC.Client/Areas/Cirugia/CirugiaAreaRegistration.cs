using System.Web.Mvc;

namespace SACC.Client.Areas.Cirugia
{
    public class CirugiaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Cirugia";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Cirugia_default",
                "Cirugia/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}