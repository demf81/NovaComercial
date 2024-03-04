using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Municipio.Controllers
{
    public class MunicipioController : Controller
    {
        [Authorize]
        [HttpPost]
        public JsonResult MunicipioComboJson(OpcionesCombo _opcion, Int32 pPaisId, Int32 pEstadoId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Municipio.DtoComboMunicipio> res = LogicaNegocio.NovaComercial.SACC.Municipio.ConsultarCombo("", pPaisId, pEstadoId);

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

            foreach (Modelo.NovaComercial.SACC.Municipio.DtoComboMunicipio item in res.Datos)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.MunicipioDescripcion.ToString(),
                        Value = item.MunicipioId.ToString()
                    }
                );
            }

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}