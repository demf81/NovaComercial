using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Pais.Controllers
{
    public class PaisController : Controller
    {
        [Authorize]
        [HttpPost]
        public JsonResult PaisComboJson(OpcionesCombo _opcion)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Pais.DtoComboPais> res = LogicaNegocio.NovaComercial.SACC.Pais.ConsultarCombo("");

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

            foreach (Modelo.NovaComercial.SACC.Pais.DtoComboPais item in res.Datos)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.PaisDescripcion.ToString(),
                        Value = item.PaisId.ToString()
                    }
                );
            }

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}