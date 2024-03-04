using System;
using System.Configuration;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Membresia.Controllers
{
    public class MembresiaController : Client.Controllers.BaseController
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
        public JsonResult MembresiaGridJson(DateTime? pFechaInicio, DateTime? pFechaFin, DateTime? pVigenciaInicio, DateTime? pVigenciaFin, Int16 pMembresiaTipoId, String pNombre, Int32 pNumSocio, Int16 pClaveFamiliar, Int32 pNumRecibo, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Membresia.DtoGridMembresia> res = LogicaNegocio.NovaComercial.SACC.Membresia.ConsultarGrid(pFechaInicio, pFechaFin, pVigenciaInicio, pVigenciaFin, pMembresiaTipoId, pNombre, pNumSocio, pClaveFamiliar, pNumRecibo, pEstatusId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        //[Authorize]
        //[HttpGet]
        //public ActionResult Edit(Int32 pMembresiaId)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/SessionExpirada");

        //    if (HttpContext.Session["Permisos"] == null)
        //        Response.Redirect("~/Home/SinPermiso");

        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
            
        //    #region VARIABLES DE MENU
        //    TempData["lblNombre"] = GetNombreUsuario();
        //    if (HttpContext.Session["Foto"] != null)
        //        TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
        //    #endregion
            
        //    return View();
        //}
        
        //[Authorize]
        //[HttpPost]
        //public ActionResult Edit(Modelo.NovaComercial.SACC.Membresia.DtoMembresia model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/SessionExpirada");

        //    if (HttpContext.Session["Permisos"] == null)
        //        Response.Redirect("~/Home/SinPermiso");

        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
            
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();
            
        //    #region VARIABLES DE MENU
        //    TempData["lblNombre"] = GetNombreUsuario();
        //    if (HttpContext.Session["Foto"] != null)
        //        TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
        //    #endregion

        //    if (res.Error)
        //        return View(model);
        //    else
        //        return RedirectToAction("Index", "Membresia");
        //}




        //[Authorize]
        //[HttpGet]
        //public ActionResult Delete(Int32 pMembresiaId)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/SessionExpirada");

        //    if (HttpContext.Session["Permisos"] == null)
        //        Response.Redirect("~/Home/SinPermiso");

        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
            
        //    #region VARIABLES DE MENU
        //    TempData["lblNombre"] = GetNombreUsuario();
        //    if (HttpContext.Session["Foto"] != null)
        //        TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
        //    #endregion
            
        //    return View();
        //}
                
        //[Authorize]
        //[HttpPost]
        //public JsonResult Delete(Modelo.NovaComercial.SACC.Membresia.DtoMembresia model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/SessionExpirada");

        //    if (HttpContext.Session["Permisos"] == null)
        //        Response.Redirect("~/Home/SinPermiso");

        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
            
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();;
            
        //    #region VARIABLES DE MENU
        //    TempData["lblNombre"] = GetNombreUsuario();
        //    if (HttpContext.Session["Foto"] != null)
        //        TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
        //    #endregion

        //    if (res.Error)
        //    {
        //        Response.StatusCode = (int)(HttpStatusCode.InternalServerError);
        //        res.StatusCode = (int)(HttpStatusCode.InternalServerError);
        //    }
        //    else
        //    {
        //        Response.StatusCode = (int)(HttpStatusCode.OK);
        //        res.StatusCode = (int)(HttpStatusCode.OK);
        //        res.DelayTime = true;
        //    }

        //    res.MuestraAlert = true;

        //    return Json(new { success = (res.Error == false ? true : false), data = res });
        //}




        [Authorize]
        [HttpGet]
        public ActionResult Create()
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

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Create(Modelo.NovaComercial.SACC.Membresia.DtoMembresia model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.SACC.Membresia obj = new Entidades.NovaComercial.SACC.Membresia
            {
                MembresiaId              = model.MembresiaId,
                //Fecha                    = model.Fecha,
                //Vigencia                 = model.Vigencia,
                MembresiaTipoId          = model.MembresiaTipoId,
                ContratanteId            = model.ContratanteId,
                CantidadAfiliados        = model.CantidadAfiliados,
                CantidadAdicionales      = model.CantidadAdicionales,
                NumPedido                = model.NumPedido,
                NumRecibo                = model.NumRecibo,
                UsuarioCreacionId        = GetUsuarioId(),
                UsuarioModificacionId    = GetUsuarioId()
            };

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.Membresia.Guardar(obj);
            
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
        public JsonResult MembresiaElementoJson(Int32 pMembresiaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Membresia.DtoMembresia> res = LogicaNegocio.NovaComercial.SACC.Membresia.ConsultarPorId(pMembresiaId);

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
        public ActionResult CreatePDF()
        {
            return View();
        }

        public FileResult CreatePDFJson(Int32 pMembresiaId)
        {
            LogicaNegocio.NovaComercial.SACC.Membresia.CreatePDF(pMembresiaId);

            try
            {
                string path = ConfigurationManager.AppSettings["DirectorioPrincipal"].ToString() + "\\Plantilla\\Membresia" + pMembresiaId.ToString() + ".pdf";
                byte[] bytes = System.IO.File.ReadAllBytes(path);

                return File(bytes, "application/octet-stream", "Membresia" + pMembresiaId.ToString() + ".pdf");
            }
            catch (Exception exc)
            {
                //RedirectToAction("Main", "ErrorCreatePdf");
                Response.Redirect("~/Home/ErrorCreatePdf?pError=" + exc.Message.ToString());
                //, new { @pError = exc.ToString() });
                return null;
            }
        }




        [Authorize]
        [HttpPost]
        public JsonResult ActualizaVigencia(Int32 pMembresiaId, String pNumeroSocio)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            char spearator = '-';

            //pNumeroSocio = "563397-03";

            String[] strlist = pNumeroSocio.Split(spearator);

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.Membresia.ActualizarVigencia(pMembresiaId, Int32.Parse(strlist[0]), Int16.Parse(strlist[1]));

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
        public ActionResult _LineaVida()
        {
            return PartialView();
        }
    }
}