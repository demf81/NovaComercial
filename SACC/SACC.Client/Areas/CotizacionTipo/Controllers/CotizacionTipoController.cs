using System.Web.Mvc;


namespace SACC.Client.Areas.CotizacionTipo.Controllers
{
    public class CotizacionTipoController : Client.Controllers.BaseController
    {
        public ActionResult Index()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            return View();
        }
    }
}