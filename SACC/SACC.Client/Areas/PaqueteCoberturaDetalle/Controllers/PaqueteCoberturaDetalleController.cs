using System;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.PaqueteCoberturaDetalle.Controllers
{
    public class PaqueteCoberturaDetalleController : SACC.Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


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
        [HttpGet]
        public ActionResult _CtrlUserCirugiaPaqueteCoberturaDetalleView()
        {
            return PartialView();
        }




        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserEstudioPaqueteCoberturaDetalleView()
        {
            return View();
        }




        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserMaterialPaqueteCoberturaDetalleView()
        {
            return PartialView();
        }




        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserMedicamentoPaqueteCoberturaDetalleView()
        {
            return PartialView();
        }





        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserServicioMedicoPaqueteCoberturaDetalleView()
        {
            return PartialView();
        }

        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserPaqueteCoberturaDetalleViewJson(LogicaNegocio.SqlOpciones pOpcion, Int32 pPaqueteId, Int32 pItemId, String pItemDescripcion, Int16 pItenTipoId, Int16 pEstatusId)
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