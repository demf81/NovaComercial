using System.Web.Mvc;

namespace SACC.Client.Areas.MedicamentoCuadroTipo
{
    public class MedicamentoCuadroTipoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MedicamentoCuadroTipo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MedicamentoCuadroTipo_default",
                "MedicamentoCuadroTipo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
