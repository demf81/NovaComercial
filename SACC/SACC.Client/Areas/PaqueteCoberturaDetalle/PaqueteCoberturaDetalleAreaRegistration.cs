using System.Web.Mvc;

namespace SACC.Client.Areas.PaqueteCoberturaDetalle
{
    public class PaqueteCoberturaDetalleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PaqueteCoberturaDetalle";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PaqueteCoberturaDetalle_default",
                "PaqueteCoberturaDetalle/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
