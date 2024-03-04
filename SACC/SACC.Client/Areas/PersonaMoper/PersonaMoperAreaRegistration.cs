using System.Web.Mvc;

namespace SACC.Client.Areas.PersonaMoper
{
    public class PersonaMoperAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PersonaMoper";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PersonaMoper_default",
                "PersonaMoper/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
