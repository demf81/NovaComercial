using System.Web.Mvc;

namespace SACC.Client.Areas.Municipio
{
    public class MunicipioAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Municipio";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Municipio_default",
                "Municipio/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
