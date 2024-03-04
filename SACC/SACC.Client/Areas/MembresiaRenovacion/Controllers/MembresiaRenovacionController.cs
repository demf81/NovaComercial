using System;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.MembresiaRenovacion.Controllers
{
    public class MembresiaRenovacionController : Client.Controllers.BaseController
    {
        const Int16 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index(Int16 pOpcion)
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

            ViewBag.Opcion = pOpcion;

            return View();
        }

        [HttpPost]
        public JsonResult MembresiaRenovacionGridJson(DateTime? pFechaInicio, DateTime? pFechaFin, DateTime? pVigenciaInicio, DateTime? pVigenciaFin, Int16 pMembresiaTipoId, String pNumSocio, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoGridMembresiaRenovacion> res = LogicaNegocio.NovaComercial.SACC.MembresiaRenovacion.ConsultarGrid(pFechaInicio, pFechaFin, pVigenciaInicio, pVigenciaFin, pMembresiaTipoId, pNumSocio, pEstatusId);

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
        [HttpGet]
        public ActionResult Create(Int64 pMembresiaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            ViewBag.MembresiaId = pMembresiaId;

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoMembresiaRenovacion model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.SACC.MembresiaRenovacion obj = new Entidades.NovaComercial.SACC.MembresiaRenovacion
            {
                MembresiaRenovacionId = model.MembresiaRenovacionId,
                MembresiaId           = model.MembresiaId,
                Fecha                 = DateTime.Now,
                NumPedido             = model.NumPedido,
                NumRecibo             = model.NumRecibo,
                UsuarioCreacionId     = GetUsuarioId(),
                UsuarioModificacionId = GetUsuarioId()
            };

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.MembresiaRenovacion.Guardar(obj);

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




        [HttpPost]
        public JsonResult MembresiaRenovacionElementoQJson(Int32 pMembresiaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoMembresiaRenovacionQ> res = LogicaNegocio.NovaComercial.SACC.MembresiaRenovacion.ConsultarPorId(pMembresiaId);

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