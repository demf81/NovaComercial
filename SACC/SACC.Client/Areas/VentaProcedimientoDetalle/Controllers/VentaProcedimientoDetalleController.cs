using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.VentaProcedimientoDetalle.Controllers
{
    public class VentaProcedimientoDetalleController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult VentaProcedimientoDetalleGridJson(Int32 pVentaDetalleId, Int32 pVentaId, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalle> res = LogicaNegocio.NovaComercial.SACC.VentaProcedimientoDetalle.ConsultarGrid(pVentaDetalleId, pVentaId, pEstatusId);

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
        public JsonResult VentaProcedimientoDetalleGridConPrecioJson(Int32 pVentaDetalleId, Int32 pVentaId, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalleConPrecio> res = LogicaNegocio.NovaComercial.SACC.VentaProcedimientoDetalle.ConsultarGridConPrecio(pVentaDetalleId, pVentaId, pEstatusId);

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
        public JsonResult Edit(List<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoVentaProcedimientoDetalle> model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");

            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            foreach (Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoVentaProcedimientoDetalle item in model)
            {
                Entidades.NovaComercial.SACC.VentaProcedimientoDetalle x = new Entidades.NovaComercial.SACC.VentaProcedimientoDetalle
                {
                    VentaProcedimientoDetalleId = item.VentaProcedimientoDetalleId,
                    Cantidad                    = item.Cantidad,
                    CantidadOriginal            = item.CantidadOriginal,
                    CantidadBase                = item.CantidadBase,
                    Costo                       = item.Costo,
                    Precio                      = item.Precio,
                    Iva                         = item.Iva,
                    SubTotal                    = item.SubTotal,
                    Seleccionado                = item.Seleccionado,
                    UsuarioCreacionId           = GetUsuarioId(),
                    UsuarioModificacionId       = GetUsuarioId()
                };

                res = LogicaNegocio.NovaComercial.SACC.VentaProcedimientoDetalle.Guardar(x);
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




        public ActionResult _CtrlUserVentaProcedimientoDetalle()
        {
            return PartialView();
        }




        public ActionResult _CtrlUserVentaProcedimientoDetalleView()
        {
            return PartialView();
        }
    }
}