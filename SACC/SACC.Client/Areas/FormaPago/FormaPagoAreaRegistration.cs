using System.Web.Mvc;

namespace SACC.Client.Areas.FormaPago
{
    public class FormaPagoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "FormaPago";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "FormaPago_default",
                "FormaPago/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
