using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.ClienteTipo.Controllers
{
    public class ClienteTipoController : Controller
    {
        [Authorize]
        [HttpPost]
        public JsonResult ClienteTipoComboJson(OpcionesCombo _opcion)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ClienteTipo.DtoComboClienteTipo> res = LogicaNegocio.NovaComercial.SACC.ClienteTipo.ConsultarCombo("");

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

            foreach (Modelo.NovaComercial.SACC.ClienteTipo.DtoComboClienteTipo item in res.Datos)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.ClienteTipoDescripcion.ToString(),
                        Value = item.ClienteTipoId.ToString()
                    });
            }

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}