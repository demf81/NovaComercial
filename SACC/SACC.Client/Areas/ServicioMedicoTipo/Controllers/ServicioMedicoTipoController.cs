using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.ServicioMedicoTipo.Controllers
{
    public class ServicioMedicoTipoController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpPost]
        public JsonResult ServicioMedicoTipoComboJson(OpcionesCombo _opcion)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ServicioTipo.DtoComboServicioTipo> res = LogicaNegocio.NovaComercial.dbo.ServicioTipo.ConsultarCombo("");

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

            foreach (Modelo.NovaComercial.dbo.ServicioTipo.DtoComboServicioTipo item in res.Datos)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.ServicioTipoDescripcion.ToString(),
                        Value = item.ServicioTipoId.ToString()
                    }
                );
            }

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}