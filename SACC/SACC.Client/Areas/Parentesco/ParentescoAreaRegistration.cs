using System.Web.Mvc;

namespace SACC.Client.Areas.Parentesco
{
    public class ParentescoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Parentesco";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Parentesco_default",
                "Parentesco/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
