using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.VentaMotivoCancelacionTipo.Controllers
{
    public class VentaMotivoCancelacionTipoController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpPost]
        public JsonResult VentaMotivoCancelacionTipoComboJson(OpcionesCombo _opcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaMotivoCancelacionTipo.DtoComboVentaMotivoCancelacionTipo> res = LogicaNegocio.NovaComercial.SACC.VentaMotivoCancelacionTipo.ConsultarCombo("");

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error)
            {
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

            if (res.Datos != null)
            {
                foreach (Modelo.NovaComercial.SACC.VentaMotivoCancelacionTipo.DtoComboVentaMotivoCancelacionTipo item in res.Datos)
                {
                    items.Add(
                        new SelectListItem
                        {
                            Text  = item.VentaMotivoCancelacionTipoDescripcion.ToString(),
                            Value = item.VentaMotivoCancelacionTipoId.ToString()
                        });
                }

                res.Lista = items;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}