using System.Web.Mvc;

namespace SACC.Client.Areas.Estudio
{
    public class EstudioAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Estudio";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Estudio_default",
                "Estudio/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
