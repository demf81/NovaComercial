using System.Web.Mvc;

namespace SACC.Client.Areas.EmpresaDatosFiscales
{
    public class EmpresaDatosFiscalesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EmpresaDatosFiscales";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "EmpresaDatosFiscales_default",
                "EmpresaDatosFiscales/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
