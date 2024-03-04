using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.ServicioSubrogadoTipo.Controllers
{
    public class ServicioSubrogadoTipoController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index()
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
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult ServicioSubrogadoTipoGridJson(String pServicioSubrogadoTipoDescripcion, Int16 pEstatusId)
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

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoGridServicioSubrogadoTipo> res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogadoTipo.ConsultarGrid(pServicioSubrogadoTipoDescripcion, -1);

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
        public ActionResult Edit(Int16 pServicioSubrogadoTipoId)
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
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            ViewBag.ServicioSubrogadoTipoId = pServicioSubrogadoTipoId;

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Edit(Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoServicioSubrogadoTipo model)
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

            Entidades.NovaComercial.SACC.ServicioSubrogadoTipo obj = new Entidades.NovaComercial.SACC.ServicioSubrogadoTipo
            {
                ServicioSubrogadoTipoId          = model.ServicioSubrogadoTipoId,
                ServicioSubrogadoTipoDescripcion = model.ServicioSubrogadoTipoDescripcion,
                UsuarioCreacionId                = GetUsuarioId(),
                UsuarioModificacionId            = GetUsuarioId(),
                FechaModificacion                = DateTime.Now
            };

            if (model.Baja == true)
                obj.UsuarioBajaId = GetUsuarioId();

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogadoTipo.Guardar(obj);
            
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
        [HttpGet]
        public ActionResult Delete(Int16 pServicioSubrogadoTipoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            ViewBag.ServicioSubrogadoTipoId = pServicioSubrogadoTipoId;

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Delete(Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoServicioSubrogadoTipo model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogadoTipo.BajaLogica(model.ServicioSubrogadoTipoId, GetUsuarioId());

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
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion
            
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Create(Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoServicioSubrogadoTipo model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");

            Entidades.NovaComercial.SACC.ServicioSubrogadoTipo obj = new Entidades.NovaComercial.SACC.ServicioSubrogadoTipo
            {
                ServicioSubrogadoTipoId          = model.ServicioSubrogadoTipoId,
                ServicioSubrogadoTipoDescripcion = model.ServicioSubrogadoTipoDescripcion,
                UsuarioCreacionId                = GetUsuarioId()
            };

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogadoTipo.Guardar(obj);
            
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
        public JsonResult ServicioSubrogadoTipoElementoJson(Int32 pServicioSubrogadoTipoId)
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

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoServicioSubrogadoTipo> res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogadoTipo.ConsultarPorId(pServicioSubrogadoTipoId);

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
        public JsonResult ServicioSubrogadoTipoComboJson(OpcionesCombo _opcion)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoComboServicioSubrogadoTipo> res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogadoTipo.ConsultarCombo("");

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
                        Value = "0"
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

            foreach (Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoComboServicioSubrogadoTipo item in res.Datos)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.ServicioSubrogadoTipoDescripcion.ToString(),
                        Value = item.ServicioSubrogadoTipoId.ToString()
                    });
            }

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}