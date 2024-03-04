using System.Web.Mvc;

namespace SACC.Client.Areas.ServicioMedicoTipo
{
    public class ServicioMedicoTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ServicioMedicoTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ServicioMedicoTipo_default",
                "ServicioMedicoTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
