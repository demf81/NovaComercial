using System.Web.Mvc;

namespace SACC.Client.Areas.ContactoTipo
{
    public class ContactoTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ContactoTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ContactoTipo_default",
                "ContactoTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
