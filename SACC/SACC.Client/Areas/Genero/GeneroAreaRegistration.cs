using System.Web.Mvc;

namespace SACC.Client.Areas.Genero
{
    public class GeneroAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Genero";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Genero_default",
                "Genero/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
