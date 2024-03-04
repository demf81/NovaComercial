using System.Web.Mvc;

namespace SACC.Client.Areas.ContratoTipo
{
    public class ContratoTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ContratoTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ContratoTipo_default",
                "ContratoTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
