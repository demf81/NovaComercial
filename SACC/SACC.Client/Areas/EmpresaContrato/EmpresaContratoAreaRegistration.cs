using System.Web.Mvc;

namespace SACC.Client.Areas.EmpresaContrato
{
    public class EmpresaContratoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EmpresaContrato";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "EmpresaContrato_default",
                "EmpresaContrato/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
