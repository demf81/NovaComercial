using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SACC.Client.Areas.TarifaDetalleDesglose.Controllers
{
    public class TarifaDetalleDesgloseController : Controller
    {
        const Int32 _AplicacionId = 167;


        public ActionResult Index()
        {
            return View();
        }
    }
}