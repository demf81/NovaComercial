using System.Web.Mvc;

namespace SACC.Client.Areas.VentaMotivoCancelacionTipo
{
    public class VentaMotivoCancelacionTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VentaMotivoCancelacionTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VentaMotivoCancelacionTipo_default",
                "VentaMotivoCancelacionTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
