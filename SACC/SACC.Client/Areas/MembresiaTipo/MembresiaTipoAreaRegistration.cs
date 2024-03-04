using System.Web.Mvc;

namespace SACC.Client.Areas.MembresiaTipo
{
    public class MembresiaTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MembresiaTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MembresiaTipo_default",
                "MembresiaTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
