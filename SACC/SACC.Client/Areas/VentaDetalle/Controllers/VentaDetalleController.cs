using System;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.VentaDetalle.Controllers
{
    public class VentaDetalleController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [HttpGet]
        [Authorize]
        public ActionResult Index() 
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult VentaDetalleGridJson(Int32 pVentaDetalleId, Int32 pVentaId, Int16 pEstatusId)
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

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalle> res = LogicaNegocio.NovaComercial.SACC.VentaDetalle.ConsultarGrid(pVentaDetalleId, pVentaId, pEstatusId);

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
        public JsonResult VentaDetalleConPrecioGridJson(Int32 pVentaDetalleId, Int32 pVentaId, Int16 pEstatusId)
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

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalleConPrecio> res = LogicaNegocio.NovaComercial.SACC.VentaDetalle.ConsultarGridConPrecio(pVentaDetalleId, pVentaId, pEstatusId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [HttpGet]
        [Authorize]
        public ActionResult _IndexView()
        {
            return PartialView();
        }




        [HttpPost]
        public JsonResult VentaDetalleElementoJson(Int32 pVentaDetalleId, Int32 pVentaId)
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

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaDetalle.DtoVentaDetalle> res = LogicaNegocio.NovaComercial.SACC.VentaDetalle.ConsultarPorId(pVentaDetalleId, pVentaId);

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