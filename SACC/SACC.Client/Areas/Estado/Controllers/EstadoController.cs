using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Estado.Controllers
{
    public class EstadoController : Controller
    {
        [Authorize]
        [HttpPost]
        public JsonResult EstadoComboJson(OpcionesCombo _opcion, Int32 pPaisId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Estado.DtoComboEstado> res = LogicaNegocio.NovaComercial.SACC.Estado.ConsultarCombo("", pPaisId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            if (_opcion == OpcionesCombo.TODOS)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = "[TODOS]",
                        Value = "-1"
                    }
                );
            }

            if (_opcion == OpcionesCombo.SELECCIONE)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = "[Seleccione...]",
                        Value = "0"
                    }
                );
            }

            foreach (Modelo.NovaComercial.SACC.Estado.DtoComboEstado item in res.Datos)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.EstadoDescripcion.ToString(),
                        Value = item.EstadoId.ToString()
                    });
            }

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}