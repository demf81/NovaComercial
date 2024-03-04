using System.Web.Mvc;

namespace SACC.Client.Areas.CoberturaCondicionTipo
{
    public class CoberturaCondicionTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CoberturaCondicionTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CoberturaCondicionTipo_default",
                "CoberturaCondicionTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
