using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.PaqueteDetalle.Controllers
{
    public class PaqueteDetalleController : SACC.Client.Controllers.BaseController
    {
        const int _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index(Int32 pPaqueteId, String pPaqueteDescripcion, String pPestaniaActiva)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            ViewBag.PaqueteId          = pPaqueteId;
            ViewBag.PaqueteDescripcion = pPaqueteDescripcion;
            ViewBag.PestaniaActiva     = pPestaniaActiva;

            return View();
        }




        [Authorize]
        [HttpPost]
        public JsonResult PaqueteDetalleListAll(int pPaqueteId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleAllServicioView> res = LogicaNegocio.NovaComercial.dbo.PaqueteDetalle.ConsultarDetalleTodosServicio(pPaqueteId, 1);

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
        public JsonResult Delete(Int32 pPaqueteDetalleId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.PaqueteDetalle.BajaLogica(pPaqueteDetalleId, GetUsuarioId());

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;
            res.MuestraAlert    = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [Authorize]
        [HttpPost]
        public JsonResult Create(List<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoPaqueteDetalle> lista)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            foreach (Modelo.NovaComercial.dbo.PaqueteDetalle.DtoPaqueteDetalle item in lista)
            {
                Entidades.NovaComercial.dbo.PaqueteDetalle obj = new Entidades.NovaComercial.dbo.PaqueteDetalle
                {
                    PaqueteDetalleId  = 0,
                    PaqueteId         = item.PaqueteId,
                    Exclusion         = false,
                    ItemTipoId        = item.ItemTipoId,
                    ItemId            = item.ItemId,
                    UsuarioCreacionId = GetUsuarioId()
                };

                res = LogicaNegocio.NovaComercial.dbo.PaqueteDetalle.Guardar(obj);

                if (res.Error) break;
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
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserCirugiaPaqueteDetalleView()
        {
            return PartialView();
        }




        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserEstudioPaqueteDetalleView()
        {
            return View();
        }




        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserMaterialPaqueteDetalleView()
        {
            return PartialView();
        }




        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserMedicamentoPaqueteDetalleView()
        {
            return PartialView();
        }





        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserServicioMedicoPaqueteDetalleView()
        {
            return PartialView();
        }

        [Authorize]
        [HttpPost]
        public JsonResult CtrlUSerPaqueteDetalleViewJson(LogicaNegocio.SqlOpciones pOpcion, Int32 pPaqueteId, Int32 pItemId, String pItemDescripcion, Int16 pItenTipoId, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleView> res = LogicaNegocio.NovaComercial.dbo.PaqueteDetalle.ConsultarDetallePorServicio(pOpcion, pPaqueteId, pItemId, pItemDescripcion, pItenTipoId, pEstatusId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.InternalServerError);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}