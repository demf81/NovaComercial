using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Genero.Controllers
{
    public class GeneroController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpPost]
        public JsonResult GeneroComboJson(OpcionesCombo _opcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Genero.DtoComboGenero> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Genero.DtoComboGenero>();


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

            items.Add(
                new SelectListItem
                {
                    Text  = "Masculino",
                    Value = "1"
                }
            );

            items.Add(
                new SelectListItem
                {
                    Text  = "Femenino",
                    Value = "2"
                }
            );

            items.Add(
                new SelectListItem
                {
                    Text  = "Indistinto",
                    Value = "3"
                }
            );

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}