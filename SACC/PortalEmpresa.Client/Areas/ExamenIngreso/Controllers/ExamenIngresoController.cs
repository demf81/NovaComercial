using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.ExamenIngreso.Controllers
{
    public class ExamenIngresoController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
