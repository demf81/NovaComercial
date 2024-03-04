using System.Web.Mvc;

namespace SACC.Client.Areas.CoberturaPeriodoTipo
{
    public class CoberturaPeriodoTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CoberturaPeriodoTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CoberturaPeriodoTipo_default",
                "CoberturaPeriodoTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
