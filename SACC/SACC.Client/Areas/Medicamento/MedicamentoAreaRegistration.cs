using System.Web.Mvc;

namespace SACC.Client.Areas.Medicamento
{
    public class MedicamentoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Medicamento";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Medicamento_default",
                "Medicamento/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
