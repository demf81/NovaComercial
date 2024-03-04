using System.Web.Mvc;

namespace SACC.Client.Areas.EmpresaContacto
{
    public class EmpresaContactoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EmpresaContacto";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "EmpresaContacto_default",
                "EmpresaContacto/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
