using System.Web.Mvc;

namespace SACC.Client.Areas.CoberturaCantidadTipo
{
    public class CoberturaCantidadTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CoberturaCantidadTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CoberturaCantidadTipo_default",
                "CoberturaCantidadTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
