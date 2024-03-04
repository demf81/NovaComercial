using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.ContratoCoberturaPaqueteExclusion.Controllers
{
    public class ContratoCoberturaPaqueteExclusionController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult _Index()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return PartialView();
        }




        [Authorize]
        [HttpPost]
        public JsonResult Edit(Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoContratoCoberturaPaqueteExclusion model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion obj = new Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion
            {
                ContratoCoberturaPaqueteExclusionId = model.ContratoCoberturaPaqueteExclusionId,
                //ContratoCoberturaPaqueteExclusionDescripcion = model.ContratoCoberturaPaqueteExclusionDescripcion,
                //EstatusId                                    = model.EstatusId,
                UsuarioCreacionId = GetUsuarioId()
            };

            //if (model.Baja == true)
            //    obj.UsuarioBajaId = GetUsuarioId();

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.Guardar(obj);

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;
            res.MuestraAlert    = true;

            if (res.Error) {
                res.DelayTime = false;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [Authorize]
        [HttpPost]
        public JsonResult Create(List<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoContratoCoberturaPaqueteExclusion> list)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();
            Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion obj = null;

            foreach (Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoContratoCoberturaPaqueteExclusion item in list)
            {
                obj = new Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion
                {
                    ContratoCoberturaPaqueteExclusionId = item.ContratoCoberturaPaqueteExclusionId,
                    ContratoCoberturaPaqueteId          = item.ContratoCoberturaPaqueteId,
                    PaqueteId                           = item.PaqueteId,
                    PaqueteDetalleId                    = item.PaqueteDetalleId,
                    ItemTipoId                          = item.ItemTipoId,
                    ItemId                              = item.ItemId,
                    ServicioId                          = item.ServicioId,
                    UsuarioCreacionId                   = GetUsuarioId()
                };

                if (item.ContratoCoberturaPaqueteExclusionId == 0)
                    res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.Guardar(obj);

                if (item.ContratoCoberturaPaqueteExclusionId > 0)
                    res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.BajaLogica(obj.ContratoCoberturaPaqueteExclusionId, obj.UsuarioCreacionId);

                if (res.Error)
                    break;
                else
                    res.Mensaje = "La exclusi&oacute;n se actualizo satisfactoriemente";
            }

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;
            res.MuestraAlert    = true;

            if (res.Error) {
                res.DelayTime = false;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [Authorize]
        [HttpPost]
        public JsonResult ContratoCoberturaPaqueteExclusionElementoJson(Int32 pContratoCoberturaPaqueteExclusionId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoContratoCoberturaPaqueteExclusion> res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.ConsultarPorId(pContratoCoberturaPaqueteExclusionId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [Authorize]
        [HttpPost]
        public JsonResult ContratoCoberturaPaqueteExclusionElementoJsonConJoin(Int32 pPaqueteId, Int32 pContratoCoberturaPaqueteId, String pItemDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion> res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.ConsultarGrid(pPaqueteId, pContratoCoberturaPaqueteId, pItemDescripcion, 1);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}