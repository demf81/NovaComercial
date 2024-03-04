using System;
using System.Web.Mvc;


namespace SACC.Client.Areas.VentaTipo.Controllers
{
    public class VentaTipoController : Controller
    {
        const Int32 _AplicacionId = 167;


        public ActionResult Index()
        {
            return View();
        }
    }
}