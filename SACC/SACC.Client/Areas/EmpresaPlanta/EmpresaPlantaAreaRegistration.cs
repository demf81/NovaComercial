using System.Web.Mvc;

namespace SACC.Client.Areas.EmpresaPlanta
{
    public class EmpresaPlantaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EmpresaPlanta";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "EmpresaPlanta_default",
                "EmpresaPlanta/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
