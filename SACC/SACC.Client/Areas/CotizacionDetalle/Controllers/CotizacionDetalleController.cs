using System;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.CotizacionDetalle.Controllers
{
    public class CotizacionDetalleController : Client.Controllers.BaseController
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
        public JsonResult CotizacionDetalleGridJson(Int32 pCotizacionDetalleId, Int32 pCotizacionId, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalle> res = LogicaNegocio.NovaComercial.SACC.CotizacionDetalle.ConsultarGrid(pCotizacionDetalleId, pCotizacionId, pEstatusId);

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
        public JsonResult CotizacionDetalleConPrecioGridJson(Int32 pCotizacionDetalleId, Int32 pCotizacionId, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalleConPrecio> res = LogicaNegocio.NovaComercial.SACC.CotizacionDetalle.ConsultarGridConPredio(pCotizacionDetalleId, pCotizacionId, pEstatusId);

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
        public JsonResult Edit(Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle obj = new Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle
            {
                CotizacionProcedimientoDetalleId = model.CotizacionProcedimientoDetalleId,
                Cantidad                         = model.Cantidad,
                CantidadOriginal                 = model.CantidadOriginal,
                CantidadBase                     = model.CantidadBase,
                Costo                            = model.Costo,
                Precio                           = model.Precio,
                Iva                              = model.Iva,
                SubTotal                         = model.SubTotal,
                Seleccionado                     = model.Seleccionado,
                UsuarioCreacionId                = GetUsuarioId(),
                UsuarioModificacionId            = GetUsuarioId()
            };

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.CotizacionProcedimientoDetalle.Guardar(obj);

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




        public ActionResult _IndexView()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            return PartialView();
        }




        [HttpPost]
        public JsonResult CotizacionDetalleElementoJson(Int32 pCotizacionDetalleId, Int32 pCotizacionId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoCotizacionDetalle> res = LogicaNegocio.NovaComercial.SACC.CotizacionDetalle.ConsultarPorId(pCotizacionDetalleId, pCotizacionId);

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