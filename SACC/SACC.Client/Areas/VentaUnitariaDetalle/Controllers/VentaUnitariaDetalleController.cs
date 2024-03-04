using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SACC.Client.Areas.VentaUnitariaDetalle.Controllers
{
    public class VentaUnitariaDetalleController : Controller
    {
        const Int32 _AplicacionId = 167;


        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult VentaUnitariaDetalleJson(int pVentaUnitariaId)
        {
            List<Entidades.NovaComercial.dbo.VentaUnitariaDetalle> res = LogicaNegocio.NovaComercial.dbo.VentaUnitariaDetalle.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralConJoin, pVentaUnitariaId, 0);

            return Json(new { success = true, result = new { data = res } });
        }
    }
}