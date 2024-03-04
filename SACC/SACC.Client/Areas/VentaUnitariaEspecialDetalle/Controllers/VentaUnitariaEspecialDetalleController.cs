using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SACC.Client.Areas.VentaUnitariaEspecialDetalle.Controllers
{
    public class VentaUnitariaEspecialDetalleController : Controller
    {
        const Int32 _AplicacionId = 167;


        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult VentaUnitariaEspecialDetalleJson(int pVentaUnitariaId)
        {
            List<SACC.Entidades.NovaComercial.dbo.VentaUnitariaDetalle> res = SACC.LogicaNegocio.NovaComercial.dbo.VentaUnitariaDetalle.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralConJoin, pVentaUnitariaId, 0);

            return Json(new { success = true, result = new { data = res } });
        }
    }
}