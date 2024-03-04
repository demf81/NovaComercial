using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.MedicamentoCuadroTipo.Controllers
{
    public class MedicamentoCuadroTipoController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpPost]
        public JsonResult MedicamentoCuadroTipoComboJson(OpcionesCombo _opcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.MedicamentoCuadroTipo.DtoComboMedicamentoCuadroTipo> res = LogicaNegocio.NovaComercial.dbo.MedicamentoCuadroTipo.ConsultarCombo("");

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

            foreach (Modelo.NovaComercial.dbo.MedicamentoCuadroTipo.DtoComboMedicamentoCuadroTipo item in res.Datos)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.MedicamentoCuadroTipoDescripcion.ToString(),
                        Value = item.MedicamentoCuadroTipoId.ToString()
                    }
                );
            }

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        //public static List<SelectListItem> MedicamentoCuadroTipoComboJson(OpcionesCombo _opcion)
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();

        //    Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.MedicamentoCuadroTipo.DtoComboMedicamentoCuadroTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.MedicamentoCuadroTipo.DtoComboMedicamentoCuadroTipo>(); SACC.LogicaNegocio.NovaComercial.dbo.MedicamentoCuadroTipo.ConsultarCombo("");

        //    if (_opcion == OpcionesCombo.TODOS)
        //    {
        //        items.Add (
        //            new SelectListItem {
        //                Text  = "[TODOS]",
        //                Value = "-1"
        //            }
        //        );
        //    }

        //    if (_opcion == OpcionesCombo.SELECCIONE)
        //    {
        //        items.Add (
        //            new SelectListItem {
        //                Text  = "[Seleccione...]",
        //                Value = "0"
        //            }
        //        );
        //    }

        //    if (res.Datos != null)
        //    {
        //        foreach (Modelo.NovaComercial.dbo.MedicamentoCuadroTipo.DtoComboMedicamentoCuadroTipo item in res.Datos)
        //        {
        //            items.Add(
        //                    new SelectListItem
        //                    {
        //                        Text = item.MedicamentoCuadroTipoDescripcion.ToString(),
        //                        Value = item.MedicamentoCuadroTipoId.ToString()
        //                    });
        //        }
        //    }

        //    return items;
        //}
    }
}