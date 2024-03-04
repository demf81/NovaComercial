using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.EmpresaDocumentoTipo.Controllers
{
    public class EmpresaDocumentoTipoController : Client.Controllers.BaseController
    {
        readonly Int32 _AplicacionId = 167;


        [Authorize]
        [HttpPost]
        public JsonResult EmpresaDocumentoTipoComboJson(OpcionesCombo _opcion)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoComboEmpresaDocumentoTipo> res = LogicaNegocio.NovaComercial.SACC.EmpresaDocumentoTipo.ConsultarCombo("");

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime = false;
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

            foreach (Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoComboEmpresaDocumentoTipo item in res.Datos)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.EmpresaDocumentoTipoDescripcion.ToString(),
                        Value = item.EmpresaDocumentoTipoId.ToString()
                    }
                );
            }

                res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}