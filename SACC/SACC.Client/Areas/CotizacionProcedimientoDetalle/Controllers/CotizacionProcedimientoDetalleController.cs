using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.CotizacionProcedimientoDetalle.Controllers
{
    public class CotizacionProcedimientoDetalleController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        public ActionResult Index()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult CotizacionProcedimientoDetalleGridJson(Int32 pCotizacionDetalleId, Int32 pCotizacionId, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalle> res = LogicaNegocio.NovaComercial.SACC.CotizacionProcedimientoDetalle.ConsultarGrid(pCotizacionDetalleId, pCotizacionId, pEstatusId);

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
        public JsonResult CotizacionProcedimientoDetalleGridConPrecioJson(Int32 pCotizacionDetalleId, Int32 pCotizacionId, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalleConPrecio> res = LogicaNegocio.NovaComercial.SACC.CotizacionProcedimientoDetalle.ConsultarGridConPrecio(pCotizacionDetalleId, pCotizacionId, pEstatusId);

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
        public JsonResult Edit(List<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle> model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            foreach (Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle item in model)
            {
                Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle x = new Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle
                {
                    CotizacionProcedimientoDetalleId = item.CotizacionProcedimientoDetalleId,
                    Cantidad                         = item.Cantidad,
                    CantidadOriginal                 = item.CantidadOriginal,
                    CantidadBase                     = item.CantidadBase,
                    Costo                            = item.Costo,
                    Precio                           = item.Precio,
                    Iva                              = item.Iva,
                    SubTotal                         = item.SubTotal,
                    Seleccionado                     = item.Seleccionado,
                    UsuarioCreacionId                = GetUsuarioId(),
                    UsuarioModificacionId            = GetUsuarioId()
                };

                res = LogicaNegocio.NovaComercial.SACC.CotizacionProcedimientoDetalle.Guardar(x);
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




        public ActionResult _CtrlUserCotizacionProcedimientoDetalle()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            return PartialView();
        }




        public ActionResult _CtrlUserCotizacionProcedimientoDetalleView()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            return PartialView();
        }
    }
}