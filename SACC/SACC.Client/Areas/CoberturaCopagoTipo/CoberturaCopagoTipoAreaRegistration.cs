using System.Web.Mvc;

namespace SACC.Client.Areas.CoberturaCopagoTipo
{
    public class CoberturaCopagoTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CoberturaCopagoTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CoberturaCopagoTipo_default",
                "CoberturaCopagoTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
