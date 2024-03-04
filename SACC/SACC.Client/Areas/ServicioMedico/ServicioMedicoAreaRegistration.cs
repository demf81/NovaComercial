using System.Web.Mvc;

namespace SACC.Client.Areas.ServicioMedico
{
    public class ServicioMedicoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ServicioMedico";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ServicioMedico_default",
                "ServicioMedico/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
